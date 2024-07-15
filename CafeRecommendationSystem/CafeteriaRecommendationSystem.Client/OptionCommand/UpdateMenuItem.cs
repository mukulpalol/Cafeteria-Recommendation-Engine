using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO.RequestDTO;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client.OptionCommand
{
    public class UpdateMenuItem : ICommand
    {
        private NetworkStream _stream;

        public UpdateMenuItem(NetworkStream stream)
        {
            _stream = stream;
        }

        public void Execute(RoleEnum role)
        {
            try
            {
                MenuItemUpdateRequestDTO menuItem = GetMenuItemUpdateDetails();
                SendUpdateMenuItemRequest(role, menuItem);
                ReceiveServerResponse();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please ensure the IDs and price are correct.");
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

        private MenuItemUpdateRequestDTO GetMenuItemUpdateDetails()
        {
            MenuItemUpdateRequestDTO menuItem = new MenuItemUpdateRequestDTO();

            Console.Write("Enter menu item ID to update: ");
            menuItem.Id = int.Parse(Console.ReadLine());

            Console.Write("Enter new menu item name (leave blank to keep current): ");
            menuItem.Name = Console.ReadLine();

            Console.Write("Enter new menu item price (leave blank to keep current): ");
            menuItem.Price = decimal.TryParse(Console.ReadLine(), out decimal priceResult) ? priceResult : (decimal?)null;

            Console.Write("Enter new menu item type id (leave blank to keep current): ");
            menuItem.TypeId = int.TryParse(Console.ReadLine(), out int typeIdResult) ? typeIdResult : (int?)null;

            Console.Write("Enter new menu item availability status id (leave blank to keep current): ");
            menuItem.AvailabilityStatusId = int.TryParse(Console.ReadLine(), out int availabilityStatusIdResult) ? availabilityStatusIdResult : (int?)null;

            return menuItem;
        }

        private void SendUpdateMenuItemRequest(RoleEnum role, MenuItemUpdateRequestDTO menuItem)
        {
            string menuItemJson = JsonConvert.SerializeObject(menuItem);
            string optionRequest = $"option|{(int)role}|2|{menuItemJson}";
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
