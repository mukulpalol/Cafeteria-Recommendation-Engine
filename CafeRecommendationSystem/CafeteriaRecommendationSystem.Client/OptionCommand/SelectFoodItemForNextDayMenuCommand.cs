using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client.OptionCommand
{
    public class SelectFoodItemForNextDayMenuCommand : ICommand
    {
        private NetworkStream _stream;
        private int _userId;        
        public SelectFoodItemForNextDayMenuCommand(int userId, NetworkStream stream)
        {
            _stream = stream;
            _userId = userId;            
        }

        public void Execute(RoleEnum role)
        {
            SelectionRequestDTO selectionRequest = new SelectionRequestDTO();
            Console.WriteLine("1. Breakfast\n2. Lunch\n3. Dinner\n");
            Console.Write("Select meal type:");
            int mealType = int.Parse(Console.ReadLine());
            Console.Write("Enter menu item id:");
            selectionRequest.MenuItemId = int.Parse(Console.ReadLine());
            selectionRequest.UserId = _userId;
            selectionRequest.Date = DateTime.UtcNow;

            string selectionJson = JsonConvert.SerializeObject(selectionRequest);
            string optionRequest = $"option|{(int)role}|1|{selectionJson}|{mealType.ToString()}";
            byte[] data = Encoding.ASCII.GetBytes(optionRequest);
            _stream.Write(data, 0, data.Length);

            byte[] response = new byte[1024];
            int bytes = _stream.Read(response, 0, response.Length);
            string serverResponse = Encoding.ASCII.GetString(response, 0, bytes);
            Console.WriteLine("\nServer response: " + serverResponse);
        }
    }
}
