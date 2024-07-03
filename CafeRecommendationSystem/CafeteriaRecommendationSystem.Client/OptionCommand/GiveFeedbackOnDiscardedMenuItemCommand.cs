using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO;
using CafeteriaRecommendationSystem.DAL.Models;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client.OptionCommand
{
    public class GiveFeedbackOnDiscardedMenuItemCommand : ICommand
    {
        private readonly NetworkStream _stream;
        private readonly int _userId;
        public GiveFeedbackOnDiscardedMenuItemCommand(int userId, NetworkStream stream)
        {
            _userId = userId;
            _stream = stream;
        }

        public void Execute(RoleEnum role)
        {
            DiscardedMenuItemFeedbackRequestDTO request = new DiscardedMenuItemFeedbackRequestDTO();
            request.UserId = _userId;
            Console.Write("Enter discarded menu item's id: ");
            request.MenuItemId = int.Parse(Console.ReadLine());
            request.Feedback += "What didn't you like about the food item?\n";
            Console.WriteLine("What didn't you like about the food item?");
            string feedback = Console.ReadLine();
            request.Feedback += feedback + "\nHow would you like the food item to taste?\n";
            Console.WriteLine("How would you like the food item to taste?");
            feedback = Console.ReadLine();
            request.Feedback += feedback + "\nShare your recipe:\n";
            Console.WriteLine("Share your recipe:");
            feedback = Console.ReadLine();
            request.Feedback += feedback + "\n";

            string selectionJson = JsonConvert.SerializeObject(request);
            string optionRequest = $"option|{(int)role}|10|{selectionJson}";
            byte[] data = Encoding.ASCII.GetBytes(optionRequest);
            _stream.Write(data, 0, data.Length);

            byte[] response = new byte[1024];
            int bytes = _stream.Read(response, 0, response.Length);
            string serverResponse = Encoding.ASCII.GetString(response, 0, bytes);
            Console.WriteLine("\nServer response: " + serverResponse);
        }
    }
}
