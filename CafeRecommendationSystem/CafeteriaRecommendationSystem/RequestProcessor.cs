using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Contollers;
using CafeteriaRecommendationSystem.Service.ServicesContract;
using Microsoft.Extensions.DependencyInjection;

namespace CafeteriaRecommendationSystem
{
    public static class RequestProcessor
    {
        public static string ProcessRequest(string request, IServiceProvider serviceProvider)
        {
            string[] parts = request.Split('|');
            string command = parts[0];

            if (command == "login")
            {
                return HandleLogin(parts, serviceProvider);
            }
            else if (command == "option")
            {
                return HandleOption(parts, serviceProvider);
            }
            return "Invalid command";
        }

        private static string HandleLogin(string[] parts, IServiceProvider serviceProvider)
        {
            string email = parts[1];
            string password = parts[2];

            var authService = serviceProvider.GetService<IAuthService>();
            var user = authService.Login(email, password);
            if (user != null)
            {
                return $"Login successful|{user.RoleId}|{user.Id}";
            }
            else
            {
                return "Login failed";
            }
        }

        private static string HandleOption(string[] parts, IServiceProvider serviceProvider)
        {
            try
            {
                int role = int.Parse(parts[1]);
                string option = parts[2];
                var controller = ControllerFactory.GetController(role, serviceProvider);
                string actionKey = $"{GetRolePrefix(role)}{option}";

                if (actionHandlers.TryGetValue(actionKey, out var actionHandler))
                {
                    return actionHandler(controller, parts);
                }
                else
                {
                    return $"Option {option} is not a valid option!";
                }
            }
            catch (Exception ex)
            {
                return $"Error handling option: {ex.Message}";
            }
        }

        private static readonly Dictionary<string, Func<BaseController, string[], string>> actionHandlers =
            new Dictionary<string, Func<BaseController, string[], string>>
            {
                { "A1", (controller, parts) => ((AdminController)controller).HandleAddMenuItem(parts) },
                { "A2", (controller, parts) => ((AdminController)controller).HandleUpdateMenuItem(parts) },
                { "A3", (controller, parts) => ((AdminController)controller).HandleDeleteMenuItem(parts) },
                { "A4", (controller, parts) => ((AdminController)controller).HandleGetAvailableMenuItems() },

                { "C1", (controller, parts) => ((ChefController)controller).HandleGetRecommendations(parts) },
                { "C2", (controller, parts) => ((ChefController)controller).HandleRollOutMenu(parts) },
                { "C3", (controller, parts) => ((ChefController)controller).HandleFinalizeMenu(parts) },
                { "C4", (controller, parts) => ((ChefController)controller).HandleGetAvailableMenuItems() },
                { "C5", (controller, parts) => ((ChefController)controller).HandleGetRolledOutMenuVotes() },
                { "C6", (controller, parts) => ((ChefController)controller).HandleGenerateDiscardedMenuItem() },
                { "C7", (controller, parts) => ((ChefController)controller).HandleViewDiscardedMenuItem() },
                { "C8", (controller, parts) => ((ChefController)controller).HandleChefHandleDiscardedMenuItems(parts) },

                { "E1", (controller, parts) => ((EmployeeController)controller).HandleEmployeeSelection(parts) },
                { "E2", (controller, parts) => ((EmployeeController)controller).HandleGetNotifications(parts) },
                { "E3", (controller, parts) => ((EmployeeController)controller).HandleGetAllFoodCharacteristics() },
                { "E4", (controller, parts) => ((EmployeeController)controller).HandleGetAvailableMenuItems() },
                { "E5", (controller, parts) => ((EmployeeController)controller).HandleSubmitFeedback(parts) },
                { "E6", (controller, parts) => ((EmployeeController)controller).HandleGetUserPreferences(parts) },
                { "E7", (controller, parts) => ((EmployeeController)controller).HandleViewDiscardedMenuItem() },
                { "E8", (controller, parts) => ((EmployeeController)controller).HandleGetRolledOutMenu(parts) },
                { "E9", (controller, parts) => ((EmployeeController)controller).HandleGetFinalizedMenu() },
                { "E10", (controller, parts) => ((EmployeeController)controller).HandleSubmitFeedbackOnDiscardedMenuItems(parts) },
                { "E11", (controller, parts) => ((EmployeeController)controller).HandleUpdateFoodPreference(parts) },
            };

        private static string GetRolePrefix(int role)
        {
            return role switch
            {
                (int)RoleEnum.Admin => "A",
                (int)RoleEnum.Chef => "C",
                (int)RoleEnum.Employee => "E",
                _ => throw new ArgumentException("Invalid role"),
            };
        }
    }
}
