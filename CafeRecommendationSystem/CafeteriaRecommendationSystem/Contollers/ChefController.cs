using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO.RequestDTO;
using CafeteriaRecommendationSystem.Service.ServicesContract;
using Newtonsoft.Json;

namespace CafeteriaRecommendationSystem.Contollers
{
    public class ChefController : BaseController
    {
        public ChefController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public string HandleGetRecommendations(string[] parts)
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

        public string HandleRollOutMenu(string[] parts)
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

        public string HandleFinalizeMenu(string[] parts)
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

        public string HandleGetAvailableMenuItems()
        {
            try
            {
                var menuItemService = GetService<IMenuItemService>();
                var menuItems = menuItemService.GetAvailableMenuItems();
                return Helpers.SerializeObjectIgnoringCycles(menuItems);
            }
            catch (Exception ex)
            {
                return $"Error retrieving available menu items: {ex.Message}";
            }
        }

        public string HandleGetRolledOutMenuVotes()
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

        public string HandleGenerateDiscardedMenuItem()
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

        public string HandleViewDiscardedMenuItem()
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

        public string HandleChefHandleDiscardedMenuItems(string[] parts)
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
