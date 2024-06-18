using CafeteriaRecommendationSystem.DAL.Models;

namespace CafeteriaRecommendationSystem.Service.ServicesContract
{
    public interface IMenuItemService : IBaseService
    {
        void AddMenuItem(MenuItem menuItem);
        void UpdateMenuItem(User user, MenuItem menuItem);
        void UpdateMenuItemAvailability(User user, MenuItem menuItem, int AvailabilityStatusId);
        void DeleteMenuItem(User user, int menuItemId);
        IEnumerable<MenuItem> GetAllMenuItems();
        MenuItem GetMenuItemById(int menuItemId);
        IEnumerable<MenuItem> GetAvailableMenuItems();
    }
}
