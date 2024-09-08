using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO.RequestDTO;
using CafeteriaRecommendationSystem.Common.DTO.ResponseDTO;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client.OptionCommand
{
    public class GetRecommendation : ICommand
    {
        private NetworkStream _stream;

        public GetRecommendation(NetworkStream stream)
        {
            _stream = stream;
        }

        public void Execute(RoleEnum role)
        {
            try
            {
                GetRecommendationRequestDTO getRecommendationRequest = GetRecommendationDetails();
                SendGetRecommendationRequest(role, getRecommendationRequest);
                ReceiveAndDisplayServerResponse();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter valid numbers for meal type and number of items.");
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

        private GetRecommendationRequestDTO GetRecommendationDetails()
        {
            GetRecommendationRequestDTO getRecommendationRequest = new GetRecommendationRequestDTO();

            Console.WriteLine("1. Breakfast");
            Console.WriteLine("2. Lunch");
            Console.WriteLine("3. Dinner");
            Console.WriteLine("4. Beverage");
            Console.Write("Select meal type: ");
            getRecommendationRequest.MenuItemType = (MenuItemTypeEnum)int.Parse(Console.ReadLine());

            Console.Write("Enter number of items to recommend: ");
            getRecommendationRequest.NumberOfItemsToRecommend = int.Parse(Console.ReadLine());

            return getRecommendationRequest;
        }

        private void SendGetRecommendationRequest(RoleEnum role, GetRecommendationRequestDTO getRecommendationRequest)
        {
            string getRecommendationRequestJson = JsonConvert.SerializeObject(getRecommendationRequest);
            string optionRequest = $"option|{(int)role}|1|{getRecommendationRequestJson}";
            byte[] data = Encoding.ASCII.GetBytes(optionRequest);
            _stream.Write(data, 0, data.Length);
        }

        private void ReceiveAndDisplayServerResponse()
        {
            byte[] response = new byte[8192];
            int bytes = _stream.Read(response, 0, response.Length);
            string serverResponse = Encoding.ASCII.GetString(response, 0, bytes);

            var menuItems = JsonConvert.DeserializeObject<List<MenuItemResponseDTO>>(serverResponse);
            if (menuItems == null)
            {
                throw new JsonSerializationException("Deserialization returned null.");
            }

            Console.WriteLine("Id\tName\tPrice\tType\tAvailability Status\tGeneral Sentiment\tSentiment Score\n");
            foreach (var item in menuItems)
            {
                Console.WriteLine($"{item.Id}\t{item.Name}\t{item.Price}\t{item.Type}\t{item.Availability}\t{item.GeneralSentiment}\t{item.SentimentScore}\n");
            }
        }
    }

}
