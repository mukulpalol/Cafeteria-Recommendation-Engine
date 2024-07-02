using CafeteriaRecommendationSystem.Common.DTO;
using CafeteriaRecommendationSystem.DAL.Models;

namespace CafeteriaRecommendationSystem.Service.ServicesContract
{
    public interface IMenuItemService
    {
        void AddMenuItem(MenuItem menuItem);
        void UpdateMenuItem(MenuItemUpdateRequestDTO menuItem);
        void UpdateMenuItemAvailability(User user, MenuItem menuItem, int AvailabilityStatusId);
        void UpdateSentimentScoreOfMenuItem(int menuItemId);
        void DeleteMenuItem(int menuItemId);
        List<MenuItem> GetAllMenuItems();
        MenuItem GetMenuItemById(int menuItemId);
        List<MenuItem> GetAvailableMenuItems();
        List<MenuItem> GetRolledOutMenu();
        List<MenuItem> GetFinalisedMenu();
    }
}
