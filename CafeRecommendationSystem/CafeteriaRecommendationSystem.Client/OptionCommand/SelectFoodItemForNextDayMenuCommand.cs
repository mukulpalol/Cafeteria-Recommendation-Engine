using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client.OptionCommand
{
    internal class SelectFoodItemForNextDayMenuCommand : ICommand
    {
        private NetworkStream _stream;
        private int _userId;
        private MenuItemTypeEnum _menuItemType;
        public SelectFoodItemForNextDayMenuCommand(int userId, NetworkStream stream, MenuItemTypeEnum menuItemType)
        {
            _stream = stream;
            _userId = userId;
            _menuItemType = menuItemType;
        }

        public void Execute(RoleEnum role)
        {
            SelectionRequestDTO selectionRequest = new SelectionRequestDTO();
            Console.Write("Enter menu item id:");
            selectionRequest.MenuItemId = int.Parse(Console.ReadLine());
            selectionRequest.UserId = _userId;
            selectionRequest.Date = DateTime.UtcNow;

            string selectionJson = JsonConvert.SerializeObject(selectionRequest);
            string optionRequest = $"option|{(int)role}|1|{selectionJson}|{_menuItemType.ToString()}";
            byte[] data = Encoding.ASCII.GetBytes(optionRequest);
            _stream.Write(data, 0, data.Length);

            byte[] response = new byte[1024];
            int bytes = _stream.Read(response, 0, response.Length);
            string serverResponse = Encoding.ASCII.GetString(response, 0, bytes);
            Console.WriteLine("\nServer response: " + serverResponse);
        }
    }
}
