namespace CafeteriaRecommendationSystem.Common.DTO.RequestDTO
{
    public class RollOutMenuRequest
    {
        public List<int> BreakfastMenuItemsToRollOut { get; set; }
        public List<int> LunchMenuItemsToRollOut { get; set; }
        public List<int> DinnerMenuItemsToRollOut { get; set; }
    }
}
