using CafeteriaRecommendationSystem.DAL.Models;

namespace CafeteriaRecommendationSystem.Service.ServicesContract
{
    public interface ISelectionService : IBaseService
    {
        void SelectItem(User user, MenuItem menuItem);
        void AddSelection(int userId, int menuItemId);
        bool CheckSelectionExists(int userId, int menuId);
    }
}
