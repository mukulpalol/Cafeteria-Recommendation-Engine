using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO.RequestDTO;
using CafeteriaRecommendationSystem.Common.DTO.ResponseDTO;
using CafeteriaRecommendationSystem.Service.ServicesContract;
using Newtonsoft.Json;

namespace CafeteriaRecommendationSystem.Contollers
{
    public class ChefController : BaseController
    {
        public ChefController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public string GetRecommendations(string[] parts)
        {
            try
            {
                var recommendationService = GetService<IRecommendationService>();
                string recommendationJson = parts[3];
                GetRecommendationRequestDTO request = JsonConvert.DeserializeObject<GetRecommendationRequestDTO>(recommendationJson);
                var recommendationItem = recommendationService.GetRecommendations(request.NumberOfItemsToRecommend, request.MenuItemType);
                return JsonConvert.SerializeObject(recommendationItem);
            }
            catch (Exception ex)
            {
                return $"Error getting recommendations: {ex.Message}";
            }
        }

        public string RollOutMenu(string[] parts)
        {
            try
            {
                var recommendationService = GetService<IRecommendationService>();
                string rollOutRequestJson = parts[3];
                List<int> menuItemIdList = JsonConvert.DeserializeObject<List<int>>(rollOutRequestJson);
                recommendationService.RollOutMenu(menuItemIdList);
                return "Menu rolled out successfully";
            }
            catch (Exception ex)
            {
                return $"Error rolling out menu: {ex.Message}";
            }
        }

        public string FinalizeMenu(string[] parts)
        {
            try
            {
                var recommendationService = GetService<IRecommendationService>();
                string rollOutRequestJson = parts[3];
                List<int> menuItemIdList = JsonConvert.DeserializeObject<List<int>>(rollOutRequestJson);
                return recommendationService.FinaliseMenu(menuItemIdList);
            }
            catch (Exception ex)
            {
                return $"Error finalizing menu: {ex.Message}";
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

        public string GetRolledOutMenuVotes()
        {
            try
            {
                var selectionService = GetService<ISelectionService>();
                var voteResponses = selectionService.GetRolledOutMenuVotes();
                return JsonConvert.SerializeObject(voteResponses);
            }
            catch (Exception ex)
            {
                return $"Error getting rolled out menu votes: {ex.Message}";
            }
        }

        public string GenerateDiscardedMenuItem()
        {
            try
            {
                var discardedMenuItemService = GetService<IDiscardedMenuItemService>();
                return discardedMenuItemService.GenerateDiscardedMenuItem();
            }
            catch (Exception ex)
            {
                return $"Error generating discarded menu item: {ex.Message}";
            }
        }

        public string ViewDiscardedMenuItem()
        {
            try
            {
                var menuItemService = GetService<IMenuItemService>();
                var menuItems = menuItemService.GetMenuItemsThatAreDiscarded();                
                return JsonConvert.SerializeObject(menuItems);
            }
            catch (Exception ex)
            {
                return $"Error getting discarded menu items : {ex.Message}";
            }
        }

        public string HandleDiscardedMenuItems(string[] parts)
        {
            try
            {
                var discardMenuItemService = GetService<IDiscardedMenuItemService>();
                var requestJson = parts[3];
                HandleMenuItemRequestDTO request = JsonConvert.DeserializeObject<HandleMenuItemRequestDTO>(requestJson);
                return discardMenuItemService.HandleDiscardMenuItem(request);
            }
            catch (Exception ex)
            {
                return $"Error handling discarded menu items: {ex.Message}";
            }
        }
    }

}
