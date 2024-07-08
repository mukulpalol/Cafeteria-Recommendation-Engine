using CafeteriaRecommendationSystem.Service.ServicesContract;

namespace CafeteriaRecommendationSystem.Service.Services
{
    public class SentimentAnalysisHelper : ISentimentAnalysisHelper
    {
        public decimal CalculateCommentSentimentScore(List<string> comments)
        {
            if (comments.Count == 0) return 0;

            decimal totalSentimentScore = 0;

            foreach (var comment in comments)
            {
                decimal sentimentScore = AnalyzeCommentSentiment(comment);
                totalSentimentScore += sentimentScore;
            }

            decimal averageSentimentScore = totalSentimentScore / comments.Count;
            
            decimal normalizedScore = (averageSentimentScore + 10) / 2;
            return Math.Clamp(normalizedScore, 0, 10);
        }

        private decimal AnalyzeCommentSentiment(string comment)
        {
            var wordScores = GetWordScores();

            comment = comment.ToLower();
            var words = comment.Split(new[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);

            decimal sentimentScore = 0M;
            bool negate = false;

            foreach (var word in words)
            {
                if (word == "not" || word == "no" || word == "never")
                {
                    negate = !negate;
                    continue;
                }

                if (wordScores.ContainsKey(word))
                {
                    sentimentScore += negate ? -wordScores[word] : wordScores[word];
                }
                negate = false;
            }

            return sentimentScore;
        }

        private Dictionary<string, decimal> GetWordScores()
        {
            return new Dictionary<string, decimal>
            {       
                { "delicious", 2 },
                { "tasty", 2 },
                { "yummy", 2 },
                { "flavorful", 1.5M },
                { "satisfying", 1.5M },
                { "exquisite", 2 },
                { "mouth-watering", 2 },
                { "savory", 1.5M },
                { "delectable", 2 },
                { "succulent", 1.5M },
                { "fresh", 1 },
                { "crispy", 1 },
                { "juicy", 1 },
                { "perfect", 2 },
                { "amazing", 2 },
                { "wonderful", 2 },
                { "excellent", 2 },
                { "great", 1.5M },
                { "fantastic", 2 },
                { "superb", 2 },
                { "awesome", 2 },
                { "outstanding", 2 },
                { "appetizing", 1.5M },
                { "heavenly", 2 },
                { "good", 1 },
                { "very good", 1.5M },
                { "enjoyable", 1.5M },
                { "yum", 1.5M },
        
                { "bland", -1 },
                { "tasteless", -2 },
                { "flavorless", -2 },
                { "bad", -1 },
                { "very bad", -1.5M },
                { "terrible", -2 },
                { "awful", -2 },
                { "disgusting", -2 },
                { "stale", -2 },
                { "cold", -1 },
                { "overcooked", -1.5M },
                { "undercooked", -1.5M },
                { "burnt", -2 },
                { "soggy", -1.5M },
                { "greasy", -1.5M },
                { "unappetizing", -2 },
                { "horrible", -2 },
                { "nasty", -2 },
                { "inedible", -2 },
                { "gross", -2 },
                { "displeasing", -1.5M },
                { "unpalatable", -2 },
                { "poor", -1 },
                { "unsatisfactory", -1.5M },
                { "unpleasant", -1.5M },
                { "mediocre", -1 }
            };
        }
    }
}
