using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO.RequestDTO;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client.OptionCommand
{
    public class SelectFoodItemForNextDayMenu : ICommand
    {
        private NetworkStream _stream;
        private int _userId;
        public SelectFoodItemForNextDayMenu(int userId, NetworkStream stream)
        {
            _stream = stream;
            _userId = userId;
        }

        public void Execute(RoleEnum role)
        {
            try
            {
                var selectionRequest = GetSelectionRequest();
                SendSelectionRequest(role, selectionRequest);
                ReceiveServerResponse();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter numeric values for meal type and menu item ID.");
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

        private SelectionRequestDTO GetSelectionRequest()
        {
            var selectionRequest = new SelectionRequestDTO();
            Console.WriteLine("1. Breakfast\n2. Lunch\n3. Dinner\n");
            Console.Write("Select meal type: ");
            selectionRequest.MealTypeId = int.Parse(Console.ReadLine());
            Console.Write("Enter menu item id: ");
            selectionRequest.MenuItemId = int.Parse(Console.ReadLine());
            selectionRequest.UserId = _userId;
            selectionRequest.Date = DateTime.Today;
            return selectionRequest;
        }

        private void SendSelectionRequest(RoleEnum role, SelectionRequestDTO selectionRequest)
        {
            string selectionJson = JsonConvert.SerializeObject(selectionRequest);
            string optionRequest = $"option|{(int)role}|1|{selectionJson}";
            byte[] data = Encoding.ASCII.GetBytes(optionRequest);
            _stream.Write(data, 0, data.Length);
        }

        private void ReceiveServerResponse()
        {
            byte[] response = new byte[8192];
            int bytes = _stream.Read(response, 0, response.Length);
            string serverResponse = Encoding.ASCII.GetString(response, 0, bytes);
            Console.WriteLine($"\nServer response: {serverResponse}\n");
        }
    }
}
