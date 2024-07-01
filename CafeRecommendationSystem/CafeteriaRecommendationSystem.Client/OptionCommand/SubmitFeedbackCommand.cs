using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client.OptionCommand
{
    public class SubmitFeedbackCommand : ICommand
    {
        private readonly NetworkStream _stream;
        private readonly int _userId;

        public SubmitFeedbackCommand(int userId, NetworkStream stream)
        {
            _stream = stream;
            _userId = userId;
        }

        public void Execute(RoleEnum role)
        {
            FeedbackRequestDTO feedback = new FeedbackRequestDTO();
            Console.Write("Enter menu item id: ");
            feedback.MenuItemId = int.Parse(Console.ReadLine());
            Console.Write("Enter rating: ");
            feedback.Rating = int.Parse(Console.ReadLine());
            Console.Write("Enter comment: ");
            feedback.Comment = Console.ReadLine();
            feedback.UserId = _userId;
            feedback.Date = DateTime.Now;

            string feedbackJson = JsonConvert.SerializeObject(feedback);
            string optionRequest = $"option|{(int)role}|5|{feedbackJson}";
            byte[] data = Encoding.ASCII.GetBytes(optionRequest);
            _stream.Write(data, 0, data.Length);

            byte[] response = new byte[1024];
            int bytes = _stream.Read(response, 0, response.Length);
            string serverResponse = Encoding.ASCII.GetString(response, 0, bytes);
            Console.WriteLine("\nServer response: " + serverResponse);

        }
    }
}
