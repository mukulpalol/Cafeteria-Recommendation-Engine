using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO.RequestDTO;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client.OptionCommand
{
    public class HandleDiscardMenuItemsCommand : ICommand
    {
        private readonly NetworkStream _stream;
        public HandleDiscardMenuItemsCommand(NetworkStream stream)
        {
            _stream = stream;
        }

        public void Execute(RoleEnum role)
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
            if (choice == 2)
            {
                requestDTO.Choice = (int)AvailabilityStatusEnum.Available;
            }            

            string requestJson = JsonConvert.SerializeObject(requestDTO);
            string optionRequest = $"option|{(int)role}|8|{requestJson}";
            byte[] data = Encoding.ASCII.GetBytes(optionRequest);
            _stream.Write(data, 0, data.Length);

            byte[] response = new byte[8192];
            int bytes = _stream.Read(response, 0, response.Length);
            string serverResponse = Encoding.ASCII.GetString(response, 0, bytes);
            Console.WriteLine($"\nServer response: {serverResponse}\n");
        }
    }
}
