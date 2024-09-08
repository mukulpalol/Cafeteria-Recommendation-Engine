using AutoMapper;
using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO.RequestDTO;
using CafeteriaRecommendationSystem.Common.DTO.ResponseDTO;
using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.Service.ServicesContract;
using Newtonsoft.Json;

namespace CafeteriaRecommendationSystem.Contollers
{
    public class AdminController : BaseController
    {        
        public AdminController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public string AddMenuItem(string[] parts)
        {
            try
            {
                var menuItemService = GetService<IMenuItemService>();
                string menuItemJson = parts[3];
                MenuItem menuItem = JsonConvert.DeserializeObject<MenuItem>(menuItemJson);
                menuItemService.AddMenuItem(menuItem);
                return $"Menu item '{menuItem.Name}' added successfully";
            }
            catch (Exception ex)
            {
                return $"Error adding menu item: {ex.Message}";
            }
        }

        public string UpdateMenuItem(string[] parts)
        {
            try
            {
                var menuItemService = GetService<IMenuItemService>();
                string menuItemJson = parts[3];
                MenuItemUpdateRequestDTO menuItem = JsonConvert.DeserializeObject<MenuItemUpdateRequestDTO>(menuItemJson);
                menuItemService.UpdateMenuItem(menuItem);
                return $"Menu item updated successfully";
            }
            catch (Exception ex)
            {
                return $"Error updating menu item: {ex.Message}";
            }
        }

        public string DeleteMenuItem(string[] parts)
        {
            try
            {
                var menuItemService = GetService<IMenuItemService>();
                int menuItemId = int.Parse(parts[3]);
                menuItemService.DeleteMenuItem(menuItemId);
                return $"Menu item deleted successfully";
            }
            catch (Exception ex)
            {
                return $"Error deleting menu item: {ex.Message}";
            }
        }

        public string GetAvailableMenuItems()
        {
            try
            {
                var menuItemService = GetService<IMenuItemService>();
                var menuItems = menuItemService.GetAvailableMenuItems();                
                return JsonConvert.SerializeObject(menuItems);
            }
            catch (Exception ex)
            {
                return $"Error retrieving available menu items: {ex.Message}";
            }
        }
    }
}
