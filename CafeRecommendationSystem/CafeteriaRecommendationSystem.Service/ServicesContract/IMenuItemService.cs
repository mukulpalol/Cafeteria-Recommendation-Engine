using CafeteriaRecommendationSystem.Common.DTO.RequestDTO;
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
        List<MenuItem> GetAvailableMenuItems();
        List<MenuItem> GetMenuItemsThatAreDiscarded();
        List<MenuItem> GetRolledOutMenu();
        List<MenuItem> GetRolledOutMenu(int userId);
        List<MenuItem> GetFinalisedMenu();
        List<Characteristic> GetAllFoodCharacteristic();
    }
}
