using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;
using CafeteriaRecommendationSystem.Service.ServicesContract;

namespace CafeteriaRecommendationSystem.Service.Services
{
    public class SelectionService : BaseService, ISelectionService
    {
        private readonly ISelectionRepository _selectionRepository;

        public SelectionService(ISelectionRepository selectionRepository)
        {
            _selectionRepository = selectionRepository;
        }

        public void SelectItem(User user, MenuItem menuItem)
        {
            Selection selection = new Selection();
            selection.UserId = user.Id;
            selection.Date = DateTime.Now;
            selection.MenuItemId = menuItem.Id;
            _selectionRepository.Add(selection);
        }
        public void AddSelection(int userId, int menuItemId)
        {
            Selection selection = new Selection();
            selection.UserId = userId;
            selection.Date = DateTime.Now;
            selection.MenuItemId = menuItemId;
            _selectionRepository.Add(selection);
        }
        public bool CheckSelectionExists(int userId, int menuId)
        {
            var exisitingSelection = _selectionRepository.GetAll().Where(s => s.UserId == userId && s.MenuItemId == menuId && s.Date == DateTime.UtcNow).FirstOrDefault();
            if (exisitingSelection == null)
            {
                return false;
            }
            return true;
        }
    }
}
