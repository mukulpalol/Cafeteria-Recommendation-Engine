using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO.RequestDTO;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client.OptionCommand
{
    public class HandleDiscardMenuItems : ICommand
    {
        private readonly NetworkStream _stream;

        public HandleDiscardMenuItems(NetworkStream stream)
        {
            _stream = stream;
        }

        public void Execute(RoleEnum role)
        {
            try
            {
                HandleMenuItemRequestDTO requestDTO = GetHandleMenuItemRequest();
                SendHandleDiscardRequest(role, requestDTO);
                ReceiveAndDisplayServerResponse();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid menu item id and choice.");
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

        private HandleMenuItemRequestDTO GetHandleMenuItemRequest()
        {
            HandleMenuItemRequestDTO requestDTO = new HandleMenuItemRequestDTO();

            Console.Write("Enter menu item id: ");
            requestDTO.MenuItemId = int.Parse(Console.ReadLine());

            Console.WriteLine("1. Delete the menu item.");
            Console.WriteLine("2. Keep the menu item.");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                requestDTO.Choice = (int)AvailabilityStatusEnum.Deleted;
            }
            else if (choice == 2)
            {
                requestDTO.Choice = (int)AvailabilityStatusEnum.Available;
            }
            else
            {
                throw new FormatException("Invalid choice. Please enter 1 or 2.");
            }

            return requestDTO;
        }

        private void SendHandleDiscardRequest(RoleEnum role, HandleMenuItemRequestDTO requestDTO)
        {
            string requestJson = JsonConvert.SerializeObject(requestDTO);
            string optionRequest = $"option|{(int)role}|8|{requestJson}";
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
