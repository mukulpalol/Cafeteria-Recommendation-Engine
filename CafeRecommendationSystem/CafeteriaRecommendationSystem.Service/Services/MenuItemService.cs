using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;
using CafeteriaRecommendationSystem.Service.ServicesContract;

namespace CafeteriaRecommendationSystem.Service.Services
{
    public class MenuItemService : BaseService, IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public MenuItemService(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public void AddMenuItem(MenuItem menuItem)
        {
            //EnsureRole(user, RoleEnum.Admin);
            _menuItemRepository.Add(menuItem);
        }

        public void UpdateMenuItem(User user, MenuItem menuItem)
        {
            EnsureRole(user, RoleEnum.Admin);
            _menuItemRepository.Update(menuItem);
        }

        public void UpdateMenuItemAvailability(User user, MenuItem menuItem, int AvailabilityStatusId)
        {
            EnsureRole(user, RoleEnum.Chef);
            menuItem.AvailabilityStatusId = AvailabilityStatusId;
            _menuItemRepository.Update(menuItem);
        }

        public void DeleteMenuItem(User user, int menuItemId)
        {
            EnsureRole(user, RoleEnum.Admin);
            _menuItemRepository.Delete(menuItemId);
        }

        public IEnumerable<MenuItem> GetAllMenuItems()
        {
            return _menuItemRepository.GetAll();
        }

        public MenuItem GetMenuItemById(int menuItemId)
        {
            return _menuItemRepository.GetById(menuItemId);
        }

        public IEnumerable<MenuItem> GetAvailableMenuItems()
        {
            return _menuItemRepository.GetAll().Where(m => m.AvailabilityStatusId == (int)AvailabilityStatusEnum.Available);
        }
    }
}
