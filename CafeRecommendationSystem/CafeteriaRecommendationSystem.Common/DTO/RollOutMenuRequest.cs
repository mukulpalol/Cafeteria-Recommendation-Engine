namespace CafeteriaRecommendationSystem.Common.DTO
{
    public class RollOutMenuRequest
    {
        public List<int> BreakfastMenuItemsToRollOut { get; set; }
        public List<int> LunchMenuItemsToRollOut { get; set; }
        public List<int> DinnerMenuItemsToRollOut { get; set; }
    }
}
