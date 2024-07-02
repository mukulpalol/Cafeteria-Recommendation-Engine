using CafeteriaRecommendationSystem.Service.ServicesContract;

namespace CafeteriaRecommendationSystem.Service.Services
{
    public class SentimentAnalysisHelper : ISentimentAnalysisHelper
    {
        public decimal CalculateCommentSentimentScore(List<string> comments)
        {
            decimal maxSentimentScore = 10;
            decimal totalSentimentScore = 0;

            if (comments.Count == 0) return 0;

            foreach (var comment in comments)
            {
                decimal sentimentScore = AnalyzeCommentSentiment(comment);
                totalSentimentScore += sentimentScore;
            }

            decimal averageSentimentScore = totalSentimentScore / comments.Count;
            decimal normalizedCommentScore = (Math.Min(averageSentimentScore, maxSentimentScore) / maxSentimentScore) * 5.0M;

            return normalizedCommentScore;
        }
        private decimal AnalyzeCommentSentiment(string comment)
        {
            var positiveWords = GetPositiveWords();
            var negativeWords = GetNegativeWords();

            comment = comment.ToLower();
            var words = comment.Split(new[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);

            int positiveScore = 0;
            int negativeScore = 0;
            bool negate = false;

            foreach (var word in words)
            {
                if (word == "not" || word == "no" || word == "never")
                {
                    negate = !negate;
                    continue;
                }

                if (positiveWords.Contains(word))
                {
                    positiveScore += negate ? -1 : 1;
                }
                else if (negativeWords.Contains(word))
                {
                    negativeScore += negate ? -1 : 1;
                }
                negate = false;
            }

            if (positiveScore > negativeScore)
            {
                return 1.0M;
            }
            else if (negativeScore > positiveScore)
            {
                return -1.0M;
            }
            else
            {
                return 0.5M;
            }
        }

        private List<string> GetPositiveWords()
        {
            var positiveWords = new List<string>
            {
            "delicious", "tasty", "yummy", "flavorful", "satisfying", "exquisite",
            "mouth-watering", "savory", "delectable", "succulent", "fresh", "crispy",
            "juicy", "perfect", "amazing", "wonderful", "excellent", "great",
            "fantastic", "superb", "awesome", "outstanding", "appetizing", "heavenly",
            "good", "very good","enjoyable", "yum"
            };

            return positiveWords;
        }

        private List<string> GetNegativeWords()
        {
            var negativeWords = new List<string>
            {
            "bland", "tasteless", "flavorless", "bad", "very bad","terrible", "awful", "disgusting",
            "stale", "cold", "overcooked", "undercooked", "burnt", "soggy", "greasy",
            "unappetizing", "horrible", "nasty", "inedible", "gross", "displeasing",
            "unpalatable", "poor", "unsatisfactory", "unpleasant", "mediocre"
            };

            return negativeWords;
        }
    }
}
