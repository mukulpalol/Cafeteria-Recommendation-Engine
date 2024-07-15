using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO.RequestDTO;
using CafeteriaRecommendationSystem.Service.ServicesContract;
using Newtonsoft.Json;

namespace CafeteriaRecommendationSystem.Contollers
{
    public class EmployeeController : BaseController
    {
        public EmployeeController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public string HandleEmployeeSelection(string[] parts)
        {
            try
            {
                var selectionService = GetService<ISelectionService>();
                var menuItemService = GetService<IMenuItemService>();
                var recommendationService = GetService<IRecommendationService>();
                string selectioinRequestJson = parts[3];
                var selectionResponse = JsonConvert.DeserializeObject<SelectionRequestDTO>(selectioinRequestJson);
                var menuItem = menuItemService.GetMenuItemById(selectionResponse.MenuItemId);

                if (!selectionService.CheckSelectionExists(selectionResponse.UserId, selectionResponse.MenuItemId))
                {
                    if (menuItem == null) return "Invalid menu item id";
                    if (!IsMenuItemTypeValid(menuItem.TypeId, selectionResponse.MealTypeId)) return $"Entered menu item is not for {((MenuItemTypeEnum)selectionResponse.MealTypeId).ToString().ToLower()}";

                    var recommendation = recommendationService.GetRecommendationByMenuItem(selectionResponse.MenuItemId);
                    if (recommendation == null) return "Entered menu item was not rolled out";

                    selectionService.AddSelection(selectionResponse.UserId, selectionResponse.MenuItemId);
                    return $"{((MenuItemTypeEnum)selectionResponse.MealTypeId).ToString()} selection complete";
                }
                return $"Selection for menu item id {selectionResponse.MenuItemId} already done";
            }
            catch (Exception ex)
            {
                return $"Error handling employee selection: {ex.Message}";
            }
        }

        private bool IsMenuItemTypeValid(int menuItemTypeId, int partType)
        {
            return menuItemTypeId == partType;
        }

        public string SubmitFeedback(string[] parts)
        {
            try
            {
                var feedbackService = GetService<IFeedbackService>();
                string feedbackRequestJson = parts[3];
                var feedbackRequest = JsonConvert.DeserializeObject<FeedbackRequestDTO>(feedbackRequestJson);
                return feedbackService.SubmitFeedback(feedbackRequest);
            }
            catch (Exception ex)
            {
                return $"Error submitting feedback: {ex.Message}";
            }
        }

        public string GetRolledOutMenu(string[] parts)
        {
            try
            {
                int userId = int.Parse(parts[3]);
                var menuItemService = GetService<IMenuItemService>();
                var menuItems = menuItemService.GetRolledOutMenu(userId);
                return Helpers.SerializeObjectIgnoringCycles(menuItems);
            }
            catch (Exception ex)
            {
                return $"Error getting rolled out menu: {ex.Message}";
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

        public string GetFinalizedMenu()
        {
            try
            {
                var menuItemService = GetService<IMenuItemService>();
                var menuItems = menuItemService.GetFinalisedMenu();
                return JsonConvert.SerializeObject(menuItems);
            }
            catch (Exception ex)
            {
                return $"Error getting finalized menu: {ex.Message}";
            }
        }

        public string GetNotifications(string[] parts)
        {
            try
            {
                int userId = int.Parse(parts[3]);
                var notificationService = GetService<INotificationService>();
                var notifications = notificationService.GetNotifications(userId);
                return notifications.Count > 0 ? string.Join("\n", notifications.Select(n => $"> {n.Message}")) : "No notifications to display.\n";
            }
            catch (Exception ex)
            {
                return $"Error getting notifications: {ex.Message}";
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

        public string GetAllFoodCharacteristics()
        {
            try
            {
                var menuItemService = GetService<IMenuItemService>();
                var characteristics = menuItemService.GetAllFoodCharacteristic();
                return JsonConvert.SerializeObject(characteristics);
            }
            catch (Exception ex)
            {
                return $"Error getting food characteristics: {ex.Message}";
            }
        }

        public string UpdateFoodPreference(string[] parts)
        {
            try
            {
                var userService = GetService<IUserService>();
                var requestDTO = JsonConvert.DeserializeObject<UpdateFoodPreferenceRequestDTO>(parts[3]);
                string response = requestDTO.Choice == 1 ? userService.AddUserPreference(requestDTO.UserId, requestDTO.CharacteristicId) : userService.DeleteUserPreference(requestDTO.UserId, requestDTO.CharacteristicId);
                return response;
            }
            catch (Exception ex)
            {
                return $"Error updating food preference: {ex.Message}";
            }
        }

        public string GetUserPreferences(string[] parts)
        {
            try
            {
                var userService = GetService<IUserService>();
                int userId = int.Parse(parts[3]);
                var preferences = userService.GetUserPreferences(userId);
                return JsonConvert.SerializeObject(preferences);
            }
            catch (Exception ex)
            {
                return $"Error getting user preferences: {ex.Message}";
            }
        }

        public string SubmitFeedbackOnDiscardedMenuItems(string[] parts)
        {
            try
            {
                var feedbackService = GetService<IFeedbackService>();
                var requestJson = parts[3];
                DiscardedMenuItemFeedbackRequestDTO request = JsonConvert.DeserializeObject<DiscardedMenuItemFeedbackRequestDTO>(requestJson);
                return feedbackService.SubmitFeedbackOfDiscardedMenuItm(request);
            }
            catch (Exception ex)
            {
                return $"Error in submitting feedback of discarded menu items: {ex.Message}";
            }
        }
    }

}
