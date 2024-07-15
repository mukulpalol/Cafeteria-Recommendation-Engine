namespace CafeteriaRecommendationSystem.Service.ServicesContract
{
    public interface ISentimentAnalysisHelper
    {
        decimal CalculateCommentSentimentScore(List<string> comments);
        string GetCommentSummary(List<string> comments);
    }
}
