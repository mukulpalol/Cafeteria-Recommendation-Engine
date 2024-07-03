namespace CafeteriaRecommendationSystem.Common.DTO.RequestDTO
{
    public class UpdateFoodPreferenceRequestDTO
    {
        public int CharacteristicId { get; set; }
        public int UserId { get; set; }
        public int Choice { get; set; }
    }
}
