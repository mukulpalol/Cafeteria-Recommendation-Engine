using CafeteriaRecommendationSystem.Common;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client.OptionCommand
{
    public class FinaliseMenu : ICommand
    {
        private readonly NetworkStream _stream;

        public FinaliseMenu(NetworkStream stream)
        {
            _stream = stream;
        }

        public void Execute(RoleEnum role)
        {
            try
            {
                var menuItemIdList = GetMenuItemIds();
                SendFinaliseMenuRequest(role, menuItemIdList);
                ReceiveServerResponse();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter comma-separated menu item IDs.");
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

        private List<int> GetMenuItemIds()
        {
            Console.Write("Enter all menu item id for finalising menu (comma separated): ");
            string menuItemIdsInput = Console.ReadLine();
            return menuItemIdsInput.Split(',').Select(int.Parse).ToList();
        }

        private void SendFinaliseMenuRequest(RoleEnum role, List<int> menuItemIdList)
        {
            string finaliseMenuJson = JsonConvert.SerializeObject(menuItemIdList);
            string optionRequest = $"option|{(int)role}|3|{finaliseMenuJson}";
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
