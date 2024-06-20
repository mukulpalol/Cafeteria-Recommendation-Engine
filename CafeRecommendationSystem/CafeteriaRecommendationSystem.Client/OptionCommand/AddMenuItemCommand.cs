using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.DAL.Models;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client.OptionCommand
{
    public class AddMenuItemCommand : ICommand
    {
        private NetworkStream _stream;

        public AddMenuItemCommand(NetworkStream stream)
        {
            _stream = stream;
        }
        public void Execute(RoleEnum role)
        {
            MenuItem menuItem = new MenuItem();

            Console.Write("Enter menu item name: ");
            menuItem.Name = Console.ReadLine();
            Console.Write("Enter menu item price: ");
            menuItem.Price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter menu item type id: ");
            menuItem.TypeId = int.Parse(Console.ReadLine());
            menuItem.AvailabilityStatusId = (int)AvailabilityStatusEnum.Available;

            string menuItemJson = JsonConvert.SerializeObject(menuItem);
            string optionRequest = $"option|{(int)role}|1|{menuItemJson}";
            byte[] data = Encoding.ASCII.GetBytes(optionRequest);
            _stream.Write(data, 0, data.Length);

            byte[] response = new byte[256];
            int bytes = _stream.Read(response, 0, response.Length);
            string serverResponse = Encoding.ASCII.GetString(response, 0, bytes);
            Console.WriteLine("\nServer response: " + serverResponse);
        }
    }
}
