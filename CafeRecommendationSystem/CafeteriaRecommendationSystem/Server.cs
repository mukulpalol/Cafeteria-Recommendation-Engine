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
        private readonly Dictionary<int, User> _sessions;

        public Server(IServiceProvider serviceProvider)
        {
            _listener = new TcpListener(IPAddress.Any, 5000);
            _serviceProvider = serviceProvider;
            _sessions = new Dictionary<int, User>();
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

            while (client.Connected)
            {
                try
                {
                    var bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        break;
                    }
                    var message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("Received: " + message);
                    
                    var responseMessage = ProcessRequest(message);

                    var response = Encoding.ASCII.GetBytes(responseMessage);
                    await stream.WriteAsync(response, 0, response.Length);
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Connection error: " + ex.Message);
                    break;
                }
            }
            client.Close();
        }

        private string ProcessRequest(string message)
        {
            var parts = message.Split('|');
            var command = parts[0];

            switch (command)
            {
                case "LOGIN":
                    var email = parts[1];
                    var password = parts[2];
                    var authService = _serviceProvider.GetService<IAuthService>();
                    var user = authService.Login(email, password);
                    if (user != null)
                    {
                        _sessions[user.Id] = user;
                        return $"SUCCESS|{user.Id}|{user.Role}";
                    }
                    return "FAILURE|Invalid credentials";

                case "PERFORM_ACTION":
                    var userId = int.Parse(parts[1]);
                    if (_sessions.ContainsKey(userId))
                    {
                        var role = _sessions[userId].Role;
                        return HandleAction(role.Id, parts.Skip(2).ToArray());
                    }
                    return "FAILURE|Session not found";

                default:
                    return "FAILURE|Unknown command";
            }
        }

        private string HandleAction(int roleId, string[] parameters)
        {
            var action = parameters[0];
            switch (roleId)
            {
                case (int)RoleEnum.Admin:
                    return HandleAdminAction(action, parameters.Skip(1).ToArray());

                case (int)RoleEnum.Chef:
                    return HandleChefAction(action, parameters.Skip(1).ToArray());

                case (int)RoleEnum.Employee:
                    return HandleEmployeeAction(action, parameters.Skip(1).ToArray());

                default:
                    return "FAILURE|Unknown role";
            }
        }

        private string HandleAdminAction(string action, string[] parameters)
        {
            // Handle admin-specific actions
            var userService = _serviceProvider.GetService<IUserService>();
            switch (action)
            {
                case "GET_USERS":
                    var users = userService.GetAllUsers();
                    return string.Join(", ", users.Select(u => u.Name));

                // Add more admin actions here

                default:
                    return "FAILURE|Unknown admin action";
            }
        }

        private string HandleChefAction(string action, string[] parameters)
        {
            // Handle chef-specific actions
            var menuItemService = _serviceProvider.GetService<IMenuItemService>();
            switch (action)
            {
                case "ADD_MENU_ITEM":
                    var menuItemName = parameters[0];
                    var menuItemType = (MenuItemType)Enum.Parse(typeof(MenuItemType), parameters[1]);
                    var menuItemPrice = decimal.Parse(parameters[2]);
                    var menuItem = new MenuItem
                    {
                        Name = menuItemName,
                        Type = menuItemType,
                        Price = menuItemPrice,
                        AvailabilityStatusId = (int)AvailabilityStatusEnum.Available
                    };
                    menuItemService.AddMenuItem(menuItem);
                    return "SUCCESS|Menu item added";

                // Add more chef actions here

                default:
                    return "FAILURE|Unknown chef action";
            }
        }

        private string HandleEmployeeAction(string action, string[] parameters)
        {
            // Handle employee-specific actions
            var feedbackService = _serviceProvider.GetService<IFeedbackService>();
            switch (action)
            {
                case "ADD_FEEDBACK":
                    var menuItemId = int.Parse(parameters[0]);
                    var rating = int.Parse(parameters[1]);
                    var comment = parameters[2];
                    var feedback = new Feedback
                    {
                        Id = menuItemId,
                        Rating = rating,
                        Comment = comment,
                        Date = DateTime.Now
                    };
                    feedbackService.SubmitFeedback(feedback);
                    return "SUCCESS|Feedback added";

                // Add more employee actions here

                default:
                    return "FAILURE|Unknown employee action";
            }
        }
    }
}
