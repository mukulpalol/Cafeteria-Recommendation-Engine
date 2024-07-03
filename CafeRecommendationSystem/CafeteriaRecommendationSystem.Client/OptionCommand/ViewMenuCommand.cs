using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO.ResponseDTO;
using CafeteriaRecommendationSystem.DAL.Models;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client.OptionCommand
{
    public class ViewMenuCommand : ICommand
    {
        private NetworkStream _stream;
        public ViewMenuCommand(NetworkStream stream)
        {
            _stream = stream;
        }
        public void Execute(RoleEnum role)
        {
            string optionRequest = $"option|{(int)role}|4";
            byte[] data = Encoding.ASCII.GetBytes(optionRequest);
            _stream.Write(data, 0, data.Length);

            byte[] response = new byte[8192];
            int bytes = _stream.Read(response, 0, response.Length);
            string serverResponse = Encoding.ASCII.GetString(response, 0, bytes);
            var menuItems = JsonConvert.DeserializeObject<List<MenuItem>>(serverResponse);
            List<MenuItemResponseDTO> items = new List<MenuItemResponseDTO>();
            foreach (var menuItem in menuItems)
            {
                MenuItemResponseDTO menuItemResponse = new MenuItemResponseDTO();
                menuItemResponse.Id = menuItem.Id;
                menuItemResponse.Name = menuItem.Name;
                menuItemResponse.Price = menuItem.Price;
                menuItemResponse.Type = ((MenuItemTypeEnum)menuItem.TypeId).ToString();
                menuItemResponse.Availability = ((AvailabilityStatusEnum)menuItem.AvailabilityStatusId).ToString();
                menuItemResponse.GeneralSentiment = menuItem.GeneralSentiment;
                menuItemResponse.SentimentScore = menuItem.SentimentScore;
                items.Add(menuItemResponse);
            }
            Console.WriteLine("Id\tName\tPrice\tType\tAvaiability Status\tGeneral Sentiment\tSentiment Score\n");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Id}\t{item.Name}\t{item.Price}\t{item.Type}\t{item.Availability}\t{item.GeneralSentiment}\t{item.SentimentScore}\n");
            }
        }
    }
}
