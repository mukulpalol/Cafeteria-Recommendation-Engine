using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO.RequestDTO;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client.OptionCommand
{
    public class SubmitFeedback : ICommand
    {
        private readonly NetworkStream _stream;
        private readonly int _userId;

        public SubmitFeedback(int userId, NetworkStream stream)
        {
            _userId = userId;
            _stream = stream;
        }

        public void Execute(RoleEnum role)
        {
            try
            {
                FeedbackRequestDTO feedback = GetFeedbackInput();

                SendFeedbackRequest(role, feedback);
                ReceiveAndDisplayServerResponse();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter valid values for menu item id and rating.");
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

        private FeedbackRequestDTO GetFeedbackInput()
        {
            FeedbackRequestDTO feedback = new FeedbackRequestDTO();

            Console.Write("Enter menu item id: ");
            feedback.MenuItemId = int.Parse(Console.ReadLine());

            Console.Write("Enter rating (1-5): ");
            feedback.Rating = int.Parse(Console.ReadLine());
            if (feedback.Rating < 1 || feedback.Rating > 5)
            {
                throw new FormatException();
            }

            Console.Write("Enter comment: ");
            feedback.Comment = Console.ReadLine();

            feedback.UserId = _userId;
            feedback.Date = DateTime.Today;

            return feedback;
        }

        private void SendFeedbackRequest(RoleEnum role, FeedbackRequestDTO feedback)
        {
            string feedbackJson = JsonConvert.SerializeObject(feedback);
            string optionRequest = $"option|{(int)role}|5|{feedbackJson}";
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
