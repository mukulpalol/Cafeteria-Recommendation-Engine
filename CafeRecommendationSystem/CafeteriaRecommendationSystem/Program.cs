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
    internal class Program
    {
        private static TcpListener listener;
        private static IServiceProvider _serviceProvider;
        public static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
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

            _serviceProvider = serviceProvider;

            //var server = new Server(serviceProvider);
            //await server.StartAsync();

            listener = new TcpListener(IPAddress.Any, 8888);
            listener.Start();
            Console.WriteLine("Server started...");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
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
                string response = ProcessRequest(request);
                byte[] responseBytes = Encoding.ASCII.GetBytes(response);
                stream.Write(responseBytes, 0, responseBytes.Length);
            }

            client.Close();
        }
        private static string ProcessRequest(string request)
        {
            string[] parts = request.Split('|');
            string command = parts[0];
            string email = parts[1];
            string password = parts[2];

            if (command == "login")
            {
                var authService = _serviceProvider.GetService<IAuthService>();
                var user = authService.Login(email, password);
                if (user != null)
                {
                    return $"Login successful|{user.RoleId}";
                }
                else
                {
                    return "Login failed";
                }
            }
            else if (command == "option")
            {
                string role = parts[1];
                string option = parts[2];

                if (role == "1" && option == "1")
                {
                    var menuItemService = _serviceProvider.GetService<IMenuItemService>();
                    string menuItemJson = parts[3];
                    MenuItem menuItem = (MenuItem)JsonConvert.DeserializeObject(menuItemJson, typeof(MenuItem));
                    menuItemService.AddMenuItem(menuItem);
                    return $"Menu item '{menuItem.Name}' added successfully";
                }
                else
                {
                    // Handle other options based on the role
                    return $"Option {option} selected";
                }
            }
            return "Invalid command";
        }
    }
}
