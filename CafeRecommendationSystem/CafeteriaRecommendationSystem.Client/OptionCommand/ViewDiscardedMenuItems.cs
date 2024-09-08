using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO.ResponseDTO;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client.OptionCommand
{
    public class ViewDiscardedMenuItems : ICommand
    {
        private readonly NetworkStream _stream;

        public ViewDiscardedMenuItems(NetworkStream stream)
        {
            _stream = stream;
        }

        public void Execute(RoleEnum role)
        {
            try
            {
                SendViewDiscardedMenuItemsRequest(role);
                ReceiveAndDisplayServerResponse();
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Network error: {ex.Message}");
            }
            catch (JsonSerializationException ex)
            {
                Console.WriteLine($"Error in response format: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void SendViewDiscardedMenuItemsRequest(RoleEnum role)
        {
            string optionRequest = $"option|{(int)role}|7";
            byte[] data = Encoding.ASCII.GetBytes(optionRequest);
            _stream.Write(data, 0, data.Length);
        }

        private void ReceiveAndDisplayServerResponse()
        {
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
                if (menuItems == null)
                {
                    throw new JsonSerializationException("Deserialization returned null.");
                }

                Console.WriteLine("Id\tName\tPrice\tType\tSentiment Score\n");
                foreach (var item in menuItems)
                {
                    Console.WriteLine($"{item.Id}\t{item.Name}\t{item.Price}\t{item.Type}\t{item.SentimentScore}\n");
                }
            }
        }
    }

}
