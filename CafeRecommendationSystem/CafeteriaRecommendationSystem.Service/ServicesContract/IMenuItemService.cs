using CafeteriaRecommendationSystem.Common.DTO.RequestDTO;
using CafeteriaRecommendationSystem.Common.DTO.ResponseDTO;
using CafeteriaRecommendationSystem.DAL.Models;

namespace CafeteriaRecommendationSystem.Service.ServicesContract
{
    public interface IMenuItemService
    {
        void AddMenuItem(MenuItem menuItem);
        void UpdateMenuItem(MenuItemUpdateRequestDTO menuItem);
        void UpdateMenuItemAvailability(MenuItem menuItem, int AvailabilityStatusId);
        void UpdateSentimentScoreOfMenuItem(int menuItemId);
        void DeleteMenuItem(int menuItemId);
        List<MenuItem> GetAllMenuItems();
        MenuItem GetMenuItemById(int menuItemId);
        List<MenuItemResponseDTO> GetAvailableMenuItems();        
        List<MenuItemResponseDTO> GetMenuItemsThatAreDiscarded();        
        List<MenuItemResponseDTO> GetRolledOutMenu(int userId);
        List<MenuItemResponseDTO> GetFinalisedMenu();
        List<ViewFoodCharacteristicsResponseDTO> GetAllFoodCharacteristic();
    }
}
