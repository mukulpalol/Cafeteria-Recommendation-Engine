using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.DAL.Models;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client.OptionCommand
{
    public class AddMenuItem : ICommand
    {
        private NetworkStream _stream;

        public AddMenuItem(NetworkStream stream)
        {
            _stream = stream;
        }
        public void Execute(RoleEnum role)
        {
            try
            {
                MenuItem menuItem = GetMenuItemDetails();
                SendAddMenuItemRequest(role, menuItem);
                ReceiveServerResponse();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please ensure the price is a decimal and the type ID is an integer.");
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

        private MenuItem GetMenuItemDetails()
        {
            MenuItem menuItem = new MenuItem();

            Console.Write("Enter menu item name: ");
            menuItem.Name = Console.ReadLine();

            Console.Write("Enter menu item price: ");
            menuItem.Price = decimal.Parse(Console.ReadLine());

            Console.Write("Enter menu item type id: ");
            menuItem.TypeId = int.Parse(Console.ReadLine());

            menuItem.AvailabilityStatusId = (int)AvailabilityStatusEnum.Available;

            return menuItem;
        }

        private void SendAddMenuItemRequest(RoleEnum role, MenuItem menuItem)
        {
            string menuItemJson = JsonConvert.SerializeObject(menuItem);
            string optionRequest = $"option|{(int)role}|1|{menuItemJson}";
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
