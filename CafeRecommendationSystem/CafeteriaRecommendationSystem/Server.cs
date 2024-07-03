using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO;
using CafeteriaRecommendationSystem.DAL;
using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.Repositories;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;
using CafeteriaRecommendationSystem.Service.Services;
using CafeteriaRecommendationSystem.Service.ServicesContract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem
{
    public class Program
    {
        private static TcpListener _listener;
        private static IServiceProvider _serviceProvider;

        public static async Task Main(string[] args)
        {
            var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            try
            {
                var configuration = new ConfigurationBuilder()
                                     .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                     .AddJsonFile("appsettings.json")
                                     .Build();

                var services = new ServiceCollection();
                ConfigureServices(services, configuration);

                _serviceProvider = services.BuildServiceProvider();

                StartServer(logger);
            }
            catch (Exception exception)
            {
                logger.Error(exception, "Stopped program because of exception");
                throw new Exception(exception.Message);
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CafeDbContext>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IMenuItemRepository, MenuItemRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IRecommendationRepository, RecommendationRepository>();
            services.AddScoped<ISelectionRepository, SelectionRepository>();
            services.AddScoped<IDiscardedMenuItemRepository, DiscardedMenuItemRepository>();
            services.AddScoped<IDiscardedMenuItemFeedbackRepository, DiscardedMenuItemFeedbackRepository>();

            services.AddScoped<IAuthService, AuthService>();            
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IMenuItemService, MenuItemService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IRecommendationService, RecommendationService>();
            services.AddScoped<ISelectionService, SelectionService>();
            services.AddScoped<ISentimentAnalysisHelper, SentimentAnalysisHelper>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDiscardedMenuItemService, DiscardedMenuItemService>();

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                loggingBuilder.AddNLog(configuration);
            });

            services.AddSingleton(new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore                
            });
        }

        private static void StartServer(Logger logger)
        {
            _listener = new TcpListener(IPAddress.Any, 8888);
            _listener.Start();
            Console.WriteLine("Server started on port 8888.");

            while (true)
            {
                TcpClient client = _listener.AcceptTcpClient();
                logger.Info($"New client connected: {client.Client.RemoteEndPoint}");
                Thread clientThread = new Thread(() => HandleClient(client));
                clientThread.Start();
            }
        }

        private static void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                string request = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                string response = RequestProcessor.ProcessRequest(request, _serviceProvider);
                byte[] responseBytes = Encoding.ASCII.GetBytes(response);
                stream.Write(responseBytes, 0, responseBytes.Length);
            }

            client.Close();
        }
    }

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
            int role = int.Parse(parts[1]);
            string option = parts[2];

            if (role == (int)RoleEnum.Admin && option == "1")
            {
                var menuItemService = serviceProvider.GetService<IMenuItemService>();
                string menuItemJson = parts[3];
                MenuItem menuItem = JsonConvert.DeserializeObject<MenuItem>(menuItemJson);
                menuItemService.AddMenuItem(menuItem);
                return $"Menu item '{menuItem.Name}' added successfully";
            }
            else if (role == (int)RoleEnum.Admin && option == "2")
            {
                var menuItemService = serviceProvider.GetService<IMenuItemService>();
                string menuItemJson = parts[3];
                MenuItemUpdateRequestDTO menuItem = JsonConvert.DeserializeObject<MenuItemUpdateRequestDTO>(menuItemJson);
                menuItemService.UpdateMenuItem(menuItem);
                return $"Menu item updated successfully";
            }
            else if (role == (int)RoleEnum.Admin && option == "3")
            {
                var menuItemService = serviceProvider.GetService<IMenuItemService>();
                int menuItemId = int.Parse(parts[3]);
                menuItemService.DeleteMenuItem(menuItemId);
                return $"Menu item deleted successfully";
            }
            else if ((role == (int)RoleEnum.Admin || role == (int)RoleEnum.Chef || role == (int)RoleEnum.Employee) && option == "4")
            {
                var menuItemService = serviceProvider.GetService<IMenuItemService>();
                var menuItems = menuItemService.GetAvailableMenuItems();
                var response = JsonConvert.SerializeObject(menuItems);
                return response;
            }
            else if (role == (int)RoleEnum.Chef && option == "1")
            {
                var recommendationService = serviceProvider.GetService<IRecommendationService>();
                string recommendationJson = parts[3];
                GetRecommendationRequestDTO getRecommendationRequest = JsonConvert.DeserializeObject<GetRecommendationRequestDTO>(recommendationJson);
                var recommendationItem = recommendationService.GetRecommendations(getRecommendationRequest.NumberOfItemsToRecommend, getRecommendationRequest.MenuItemType);
                var response = JsonConvert.SerializeObject(recommendationItem);
                return response;
            }
            else if (role == (int)RoleEnum.Chef && option == "2")
            {
                var recommendationService = serviceProvider.GetService<IRecommendationService>();
                var menuItemService = serviceProvider.GetService<IMenuItemService>();
                string rollOutRequestJson = parts[3];
                List<int> menuItemIdList = JsonConvert.DeserializeObject<List<int>>(rollOutRequestJson);
                recommendationService.RollOutMenu(menuItemIdList);
                return "Menu rolled out successfully";
            }
            else if (role == (int)RoleEnum.Chef && option == "3")
            {
                var recommendationService = serviceProvider.GetService<IRecommendationService>();
                string rollOutRequestJson = parts[3];
                List<int> menuItemIdList = JsonConvert.DeserializeObject<List<int>>(rollOutRequestJson);
                return recommendationService.FinaliseMenu(menuItemIdList);
            }
            else if (role == (int)RoleEnum.Chef && option == "5")
            {
                var selectionService = serviceProvider.GetService<ISelectionService>();
                var voteResponses = selectionService.GetRolledOutMenuVotes();
                var response = JsonConvert.SerializeObject(voteResponses);
                return response;
            }
            else if (role == (int)RoleEnum.Chef && option == "6")
            {
                var discardedMenuItemService = serviceProvider.GetService<IDiscardedMenuItemService>();
                return discardedMenuItemService.GenerateDiscardedMenuItem();
            }
            else if (role == (int)RoleEnum.Employee && option == "1")
            {
                var selectionService = serviceProvider.GetService<ISelectionService>();
                var menuItemService = serviceProvider.GetService<IMenuItemService>();
                var recommendationService = serviceProvider.GetService<IRecommendationService>();
                string selectioinRequestJson = parts[3];
                var selectionResponse = JsonConvert.DeserializeObject<SelectionRequestDTO>(selectioinRequestJson);
                var menuItem = menuItemService.GetMenuItemById(selectionResponse.MenuItemId);
                if (!selectionService.CheckSelectionExists(selectionResponse.UserId, selectionResponse.MenuItemId))
                {
                    if (menuItem == null)
                    {
                        return "Invalid menu item id";
                    }
                    if (parts[4] == MenuItemTypeEnum.Breakfast.ToString())
                    {
                        if (menuItem.TypeId != (int)MenuItemTypeEnum.Breakfast)
                        {
                            return "Entered menu item is not for breakfast";
                        }
                    }
                    else if (parts[4] == MenuItemTypeEnum.Lunch.ToString())
                    {
                        if (menuItem.TypeId != (int)MenuItemTypeEnum.Lunch)
                        {
                            return "Entered menu item is not for lunch";
                        }
                    }
                    else if (parts[4] == MenuItemTypeEnum.Dinner.ToString())
                    {
                        if (menuItem.TypeId != (int)MenuItemTypeEnum.Dinner)
                        {
                            return "Entered menu item is not for dinner";
                        }
                    }
                    var recommendation = recommendationService.GetRecommendationByMenuItem(selectionResponse.MenuItemId);
                    if (recommendation == null)
                    {
                        return "Entered menu item was not rolled out";
                    }
                    selectionService.AddSelection(selectionResponse.UserId, selectionResponse.MenuItemId);
                    return "Breakfast selection complete";
                }
                return "Breakfast selection already done";
            }
            else if (role == (int)RoleEnum.Employee && option == "5")
            {
                var feedbackService = serviceProvider.GetService<IFeedbackService>();
                string feedbackRequestJson = parts[3];
                var feedbackRequest = JsonConvert.DeserializeObject<FeedbackRequestDTO>(feedbackRequestJson);

                var result = feedbackService.SubmitFeedback(feedbackRequest);
                return result;
            }
            else if (role == (int)RoleEnum.Employee && option == "8")
            {
                var menuItemService = serviceProvider.GetService<IMenuItemService>();
                var menuItems = menuItemService.GetRolledOutMenu();
                var response = JsonConvert.SerializeObject(menuItems);
                return response;
            }
            else if (role == (int)RoleEnum.Employee && option == "9")
            {
                var menuItemService = serviceProvider.GetService<IMenuItemService>();
                var menuItems = menuItemService.GetFinalisedMenu();
                var response = JsonConvert.SerializeObject(menuItems);
                return response;
            }
            else if (role == (int)RoleEnum.Employee && option == "6")
            {
                var notificationService = serviceProvider.GetService<INotificationService>();
                int userId = int.Parse(parts[3]);
                var notifications = notificationService.GetNotifications(userId);
                string response = string.Empty;
                if (notifications.Count != 0)
                {
                    foreach (var notification in notifications)
                    {
                        response += $"> {notification.Message}\n";
                    }
                }
                else
                {
                    response = "No notifications to display.\n";
                }
                return response;
            }
            else if ((role == (int)RoleEnum.Chef || role == (int)RoleEnum.Employee) && option == "7")
            {
                var menuItemService = serviceProvider.GetService<IMenuItemService>();
                var menuItems = menuItemService.GetMenuItemsThatAreDiscarded();
                var response = JsonConvert.SerializeObject(menuItems);
                return response;
            }
            else if(role == (int)RoleEnum.Chef && option == "8")
            {
                var discardMenuItemService = serviceProvider.GetService<IDiscardedMenuItemService>();
                var requestJson = parts[3];
                HandleMenuItemRequestDTO request = JsonConvert.DeserializeObject<HandleMenuItemRequestDTO>(requestJson);
                var response = discardMenuItemService.HandleDiscardMenuItem(request);
                return response;
            }
            else if(role == (int)RoleEnum.Employee && option == "10")
            {
                var feedbackService = serviceProvider.GetService<IFeedbackService>();
                var requestJson = parts[3];
                DiscardedMenuItemFeedbackRequestDTO request = JsonConvert.DeserializeObject<DiscardedMenuItemFeedbackRequestDTO>(requestJson);
                var response = feedbackService.SubmiteFeedbackOfDiscardedMenuItm(request);
                return response;
            }
            else
            {
                // Handle other options based on the role
                return $"Option {option} is not a valid option!";
            }
        }
    }
}
