using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO.RequestDTO;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client.OptionCommand
{
    public class GiveFeedbackOnDiscardedMenuItem : ICommand
    {
        private readonly NetworkStream _stream;
        private readonly int _userId;

        public GiveFeedbackOnDiscardedMenuItem(int userId, NetworkStream stream)
        {
            _userId = userId;
            _stream = stream;
        }

        public void Execute(RoleEnum role)
        {
            try
            {
                var request = CollectFeedbackDetails();
                SendFeedbackRequest(role, request);
                ReceiveAndDisplayServerResponse();
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Network error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private DiscardedMenuItemFeedbackRequestDTO CollectFeedbackDetails()
        {
            DiscardedMenuItemFeedbackRequestDTO request = new DiscardedMenuItemFeedbackRequestDTO();
            request.UserId = _userId;

            Console.Write("Enter discarded menu item's id: ");
            request.MenuItemId = int.Parse(Console.ReadLine());

            StringBuilder feedback = new StringBuilder();
            string[] questions = {
            "What didn't you like about the food item?",
            "How would you like the food item to taste?",
            "Share your recipe:"
        };

            foreach (string question in questions)
            {
                Console.WriteLine(question);
                feedback.AppendLine(question);
                feedback.AppendLine(Console.ReadLine());
            }

            request.Feedback = feedback.ToString();
            return request;
        }

        private void SendFeedbackRequest(RoleEnum role, DiscardedMenuItemFeedbackRequestDTO request)
        {
            string selectionJson = JsonConvert.SerializeObject(request);
            string optionRequest = $"option|{(int)role}|10|{selectionJson}";
            byte[] data = Encoding.ASCII.GetBytes(optionRequest);
            _stream.Write(data, 0, data.Length);
        }

        private void ReceiveAndDisplayServerResponse()
        {
            byte[] response = new byte[8192];
            int bytes = _stream.Read(response, 0, response.Length);
            string serverResponse = Encoding.ASCII.GetString(response, 0, bytes);
            Console.WriteLine($"\nServer response: {serverResponse}\n");
        }
    }

}
