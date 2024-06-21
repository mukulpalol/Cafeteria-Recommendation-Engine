using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO;
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
            _menuItemRepository.Add(menuItem);
        }

        public void UpdateMenuItem(MenuItemUpdateRequestDTO menuItem)
        {
            var menuItemToUpdate = _menuItemRepository.GetById(menuItem.Id);
            if (menuItemToUpdate != null)
            {
                if (menuItem.Name != string.Empty) menuItemToUpdate.Name = menuItem.Name;
                if (menuItem.Price != null) menuItemToUpdate.Price = (decimal)menuItem.Price;
                if (menuItem.TypeId != null) menuItemToUpdate.TypeId = (int)menuItem.TypeId;
                if (menuItem.AvailabilityStatusId != null) menuItemToUpdate.AvailabilityStatusId = (int)menuItem.AvailabilityStatusId;
                _menuItemRepository.Update(menuItemToUpdate);
            }            
        }

        public void UpdateMenuItemAvailability(User user, MenuItem menuItem, int AvailabilityStatusId)
        {
            EnsureRole(user, RoleEnum.Chef);
            menuItem.AvailabilityStatusId = AvailabilityStatusId;
            _menuItemRepository.Update(menuItem);
        }

        public void DeleteMenuItem(int menuItemId)
        {
            var menuItem = _menuItemRepository.GetById(menuItemId);
            menuItem.AvailabilityStatusId = (int)AvailabilityStatusEnum.Deleted;
            _menuItemRepository.Update(menuItem);
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
