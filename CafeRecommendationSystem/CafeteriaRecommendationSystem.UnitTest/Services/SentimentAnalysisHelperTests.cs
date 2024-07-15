using CafeteriaRecommendationSystem.Service.Services;
using CafeteriaRecommendationSystem.Service.ServicesContract;

namespace CafeteriaRecommendationSystem.UnitTest.Services
{
    [TestFixture]
    public class SentimentAnalysisHelperTests
    {
        private ISentimentAnalysisHelper _sentimentAnalysisHelper;

        [SetUp]
        public void Setup()
        {
            _sentimentAnalysisHelper = new SentimentAnalysisHelper();
        }

        [Test]
        public void CalculateCommentSentimentScore_PositiveComments_ReturnsValidScore()
        {
            List<string> comments = new List<string> {
                "This food is delicious and satisfying.",
                "The service was excellent!"
            };
            decimal score = _sentimentAnalysisHelper.CalculateCommentSentimentScore(comments);
            Assert.That(score, Is.InRange(0, 10));
        }

        [Test]
        public void CalculateCommentSentimentScore_EmptyComments_ReturnsZero()
        {
            List<string> comments = new List<string>();
            decimal score = _sentimentAnalysisHelper.CalculateCommentSentimentScore(comments);
            Assert.AreEqual(0, score);
        }

        [Test]
        public void CalculateCommentSentimentScore_MixedSentiment_ReturnsNormalizedScore()
        {
            List<string> comments = new List<string> {
                "The food was good but the service was terrible.",
                "Not bad overall."
            };
            decimal score = _sentimentAnalysisHelper.CalculateCommentSentimentScore(comments);
            Assert.That(score, Is.InRange(0, 10));
        }

        [Test]
        public void CalculateCommentSentimentScore_SingleComment_ReturnsExpectedScore()
        {
            List<string> comments = new List<string> { "The food was amazing" };
            decimal score = _sentimentAnalysisHelper.CalculateCommentSentimentScore(comments);
            Assert.That(score, Is.EqualTo(6));
        }

        [Test]
        public void GetCommentSummary_OnlyPositiveWords_ReturnsMostFrequentPositiveWord()
        {
            var comments = new List<string> {
                "The food is delicious and tasty",
                "It was a delicious meal",
                "Such a fantastic and amazing place"
            };

            var result = _sentimentAnalysisHelper.GetCommentSummary(comments);

            Assert.AreEqual("delicious;", result);
        }

        [Test]
        public void GetCommentSummary_OnlyNegativeWords_ReturnsMostFrequentNegativeWord()
        {
            var comments = new List<string> {
                "The food was awful and disgusting",
                "It was a terrible experience",
                "Such a horrible and nasty place"
            };

            var result = _sentimentAnalysisHelper.GetCommentSummary(comments);

            Assert.AreEqual("awful", result);
        }

        [Test]
        public void GetCommentSummary_BothPositiveAndNegativeWords_ReturnsMostFrequentPositiveAndNegativeWords()
        {
            var comments = new List<string> {
                "The food is delicious but the service is terrible",
                "It was a wonderful experience but the staff was awful",
                "Such a fantastic place but the food was horrible"
            };

            var result = _sentimentAnalysisHelper.GetCommentSummary(comments);

            Assert.AreEqual("delicious;terrible", result);
        }

        [Test]
        public void GetCommentSummary_NoRelevantWords_ReturnsEmptyString()
        {
            var comments = new List<string> {
                "The event was okay",
                "It was fine",
                "Nothing special about the place"
            };

            var result = _sentimentAnalysisHelper.GetCommentSummary(comments);

            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void GetCommentSummary_EmptyCommentsList_ReturnsEmptyString()
        {
            var comments = new List<string>();

            var result = _sentimentAnalysisHelper.GetCommentSummary(comments);

            Assert.AreEqual(string.Empty, result);
        }
    }
}
