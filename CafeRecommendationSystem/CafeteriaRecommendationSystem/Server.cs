using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO;
using CafeteriaRecommendationSystem.DAL;
using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.Repositories;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;
using CafeteriaRecommendationSystem.Service.Services;
using CafeteriaRecommendationSystem.Service.ServicesContract;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
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
            ConfigureServices();
            StartServer();
        }

        private static void ConfigureServices()
        {
            _serviceProvider = new ServiceCollection()
                .AddDbContext<CafeDbContext>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IFeedbackRepository, FeedbackRepository>()
                .AddScoped<IMenuItemRepository, MenuItemRepository>()
                .AddScoped<INotificationRepository, NotificationRepository>()
                .AddScoped<IRecommendationRepository, RecommendationRepository>()
                .AddScoped<ISelectionRepository, SelectionRepository>()
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<IBaseService, BaseService>()
                .AddScoped<IFeedbackService, FeedbackService>()
                .AddScoped<IMenuItemService, MenuItemService>()
                .AddScoped<INotificationService, NotificationService>()
                .AddScoped<IRecommendationService, RecommendationService>()
                .AddScoped<ISelectionService, SelectionService>()
                .AddScoped<IUserService, UserService>()
                .BuildServiceProvider();
        }

        private static void StartServer()
        {
            _listener = new TcpListener(IPAddress.Any, 8888);
            _listener.Start();
            Console.WriteLine("Server started...");

            while (true)
            {
                TcpClient client = _listener.AcceptTcpClient();
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
            else if (role == (int)RoleEnum.Admin && option == "4")
            {
                var menuItemService = serviceProvider.GetService<IMenuItemService>();
                var menuItems = menuItemService.GetAvailableMenuItems().ToList();
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
            else
            {
                // Handle other options based on the role
                return $"Option {option} selected";
            }
        }
    }
}
