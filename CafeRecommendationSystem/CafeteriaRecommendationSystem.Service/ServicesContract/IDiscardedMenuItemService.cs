using CafeteriaRecommendationSystem.Common.DTO.RequestDTO;

namespace CafeteriaRecommendationSystem.Service.ServicesContract
{
    public interface IDiscardedMenuItemService
    {
        public string GenerateDiscardedMenuItem();        
        string HandleDiscardMenuItem(HandleMenuItemRequestDTO requestDTO);
    }
}
