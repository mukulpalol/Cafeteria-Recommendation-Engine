namespace CafeteriaRecommendationSystem.Common.DTO.RequestDTO
{
    public class GetRecommendationRequestDTO
    {
        public int NumberOfItemsToRecommend { get; set; }
        public MenuItemTypeEnum MenuItemType { get; set; }
    }
}
