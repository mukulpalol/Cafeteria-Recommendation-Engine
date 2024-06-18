using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.Service.ServicesContract;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem
{
    public class Server
    {
        private readonly TcpListener _listener;
        private readonly IServiceProvider _serviceProvider;

        public Server(string ip, int port, IServiceProvider serviceProvider)
        {
            _listener = new TcpListener(IPAddress.Parse(ip), port);
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync()
        {
            _listener.Start();
            Console.WriteLine("Server started...");

            while (true)
            {
                var client = await _listener.AcceptTcpClientAsync();
                Console.WriteLine("Client connected...");
                _ = HandleClientAsync(client);
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            var buffer = new byte[1024];
            var stream = client.GetStream();
            var bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            var message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Received: " + message);
            
            var responseMessage = ProcessRequest(message);

            var response = Encoding.ASCII.GetBytes(responseMessage);
            await stream.WriteAsync(response, 0, response.Length);
            client.Close();
        }

        private string ProcessRequest(string message)
        {                        
            var parts = message.Split('|');
            var command = parts[0];
            var userService = _serviceProvider.GetService<IUserService>();
            var role = (Role)Enum.Parse(typeof(Role), parts[1]);
            var userId = int.Parse(parts[2]);
            var user = userService.GetUserById(userId);

            switch (command)
            {
                case "LOGIN":
                    var email = parts[3];
                    var password = parts[4];
                    var authService = _serviceProvider.GetService<IAuthService>();
                    user = authService.Login(email, password);
                    if (user != null)
                    {
                        return $"SUCCESS|{user.Id}|{user.Role}";
                    }
                    return "FAILURE|Invalid credentials";

                case "GET_USERS":
                    if (role.Id != (int)RoleEnum.Admin)
                        return "FAILURE|Access denied";
                    userService = _serviceProvider.GetService<IUserService>();
                    var users = userService.GetAllUsers();
                    return string.Join(", ", users.Select(u => u.Name));

                case "ADD_MENU_ITEM":
                    if (role.Id != (int)RoleEnum.Chef && role.Id != (int)RoleEnum.Admin)
                        return "FAILURE|Access denied";
                    var menuItemName = parts[3];
                    var menuItemType = (MenuItemType)Enum.Parse(typeof(MenuItemType), parts[4]);
                    var menuItemPrice = decimal.Parse(parts[5]);
                    var menuItemService = _serviceProvider.GetService<IMenuItemService>();
                    var menuItem = new MenuItem
                    {
                        Name = menuItemName,
                        Type = menuItemType,
                        Price = menuItemPrice,
                        AvailabilityStatusId = (int)AvailabilityStatusEnum.Available,                                                
                    };
                    menuItemService.AddMenuItem( menuItem);
                    return "SUCCESS|Menu item added";

                case "VIEW_MENU":
                    var menuService = _serviceProvider.GetService<IMenuItemService>();
                    var menuItems = menuService.GetAllMenuItems();
                    return string.Join(", ", menuItems.Select(m => $"{m.Name} {m.Price} {m.Type.TypeName}"));

                case "ADD_FEEDBACK":
                    var menuItemId = int.Parse(parts[3]);
                    var rating = int.Parse(parts[4]);
                    var comment = parts[5];
                    var feedbackService = _serviceProvider.GetService<IFeedbackService>();
                    var feedback = new Feedback
                    {
                        MenuItemId = menuItemId,
                        UserId = userId,
                        Rating = rating,
                        Comment = comment,
                        Date = DateTime.Now
                    };
                    feedbackService.SubmitFeedback(feedback);
                    return "SUCCESS|Feedback added";

                case "VIEW_NOTIFICATIONS":
                    var notificationService = _serviceProvider.GetService<INotificationService>();
                    var notifications = notificationService.GetNotifications(user);
                    return string.Join(", ", notifications.Select(n => $"{n.Message}"));

                default:
                    return "FAILURE|Unknown command";
            }
        }
    }
}
