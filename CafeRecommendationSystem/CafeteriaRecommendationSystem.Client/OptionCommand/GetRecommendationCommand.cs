using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client.OptionCommand
{
    public class GetRecommendationCommand : ICommand
    {
        private NetworkStream _stream;
        public GetRecommendationCommand(NetworkStream stream)
        {
            _stream = stream;
        }
        public void Execute(RoleEnum role)
        {
            GetRecommendationRequestDTO getRecommendationRequest = new GetRecommendationRequestDTO();
            Console.WriteLine("1. Breakfast");
            Console.WriteLine("2. Lunch");
            Console.WriteLine("3. Dinner");
            Console.WriteLine("4. Beverage");
            Console.Write("Select meal type:");
            getRecommendationRequest.MenuItemType = (MenuItemTypeEnum)int.Parse(Console.ReadLine());
            Console.Write("Enter number of items to recommend: ");
            getRecommendationRequest.NumberOfItemsToRecommend = int.Parse(Console.ReadLine());

            string getRecommendatioRequestJson = JsonConvert.SerializeObject(getRecommendationRequest);
            string optionRequest = $"option|{(int)role}|1|{getRecommendatioRequestJson}";
            byte[] data = Encoding.ASCII.GetBytes(optionRequest);
            _stream.Write(data, 0, data.Length);

            byte[] response = new byte[8192];
            int bytes = _stream.Read(response, 0, response.Length);
            string serverResponse = Encoding.ASCII.GetString(response, 0, bytes);

            var menuItems = JsonConvert.DeserializeObject<List<MenuItemResponseDTO>>(serverResponse);

            Console.WriteLine("Id\tName\tPrice\tType\tAvaiability Status\tGeneral Sentiment\tSentiment Score\n");
            foreach (var item in menuItems)
            {
                Console.WriteLine($"{item.Id}\t{item.Name}\t{item.Price}\t{item.Type}\t{item.Availability}\t{item.GeneralSentiment}\t{item.SentimentScore}\n");
            }
        }
    }
}
