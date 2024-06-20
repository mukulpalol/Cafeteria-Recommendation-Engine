namespace CafeteriaRecommendationSystem.Common.DTO
{
    public class GetRecommendationRequestDTO
    {
        public int NumberOfItemsToRecommend { get; set; }
        public MenuItemTypeEnum MenuItemType { get; set; }
    }
}
