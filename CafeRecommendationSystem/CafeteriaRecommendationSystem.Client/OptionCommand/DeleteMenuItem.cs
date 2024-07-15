using CafeteriaRecommendationSystem.Common;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client.OptionCommand
{
    public class DeleteMenuItem : ICommand
    {
        private NetworkStream _stream;

        public DeleteMenuItem(NetworkStream stream)
        {
            _stream = stream;
        }

        public void Execute(RoleEnum role)
        {
            try
            {
                int menuItemId = GetMenuItemId();
                SendDeleteMenuItemRequest(role, menuItemId);
                ReceiveServerResponse();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid menu item ID.");
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

        private int GetMenuItemId()
        {
            Console.Write("Enter menu item id to delete: ");
            return int.Parse(Console.ReadLine());
        }

        private void SendDeleteMenuItemRequest(RoleEnum role, int menuItemId)
        {
            string optionRequest = $"option|{(int)role}|3|{menuItemId}";
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
