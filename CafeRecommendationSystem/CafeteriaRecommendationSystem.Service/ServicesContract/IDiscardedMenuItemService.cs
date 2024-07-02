using CafeteriaRecommendationSystem.Common.DTO;

namespace CafeteriaRecommendationSystem.Service.ServicesContract
{
    public interface IDiscardedMenuItemService
    {
        public string GenerateDiscardedMenuItem();
        bool IsDiscardedItemGeneratedThisMonth();
        string HandleDiscardMenuItem(HandleMenuItemRequestDTO requestDTO);
    }
}
