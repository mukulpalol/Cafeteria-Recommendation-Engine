using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO.ResponseDTO;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client.OptionCommand
{
    internal class ViewDiscardedMenuItemsCommand : ICommand
    {
        private readonly NetworkStream _stream;
        public ViewDiscardedMenuItemsCommand(NetworkStream stream)
        {
            _stream = stream;
        }

        public void Execute(RoleEnum role)
        {
            string optionRequest = $"option|{(int)role}|7";
            byte[] data = Encoding.ASCII.GetBytes(optionRequest);
            _stream.Write(data, 0, data.Length);

            byte[] response = new byte[8192];
            int bytes = _stream.Read(response, 0, response.Length);
            string serverResponse = Encoding.ASCII.GetString(response, 0, bytes);
            if (serverResponse == "[]")
            {
                Console.WriteLine("No menu items in discarded list");
            }
            else
            {
                var menuItems = JsonConvert.DeserializeObject<List<MenuItemResponseDTO>>(serverResponse);
                Console.WriteLine("Id\tName\tPrice\tType\tSentiment Score\n");
                foreach (var item in menuItems)
                {
                    Console.WriteLine($"{item.Id}\t{item.Name}\t{item.Price}\t{item.Type}\t{item.SentimentScore}\n");
                }
            }
        }
    }
}
