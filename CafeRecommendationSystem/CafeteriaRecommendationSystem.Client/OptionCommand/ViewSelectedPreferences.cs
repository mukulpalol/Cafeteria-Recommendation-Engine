using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client.OptionCommand
{
    public class ViewSelectedPreferences : ICommand
    {
        private readonly int _userId;
        private readonly NetworkStream _stream;
        public ViewSelectedPreferences(int userId, NetworkStream stream)
        {
            _userId = userId;
            _stream = stream;
        }

        public void Execute(RoleEnum role)
        {
            string optionRequest = $"option|{(int)role}|6|{_userId}";
            byte[] data = Encoding.ASCII.GetBytes(optionRequest);
            _stream.Write(data, 0, data.Length);

            byte[] response = new byte[1024];
            int bytes = _stream.Read(response, 0, response.Length);
            string serverResponse = Encoding.ASCII.GetString(response, 0, bytes);
            if (serverResponse == "[]")
            {
                Console.WriteLine("You have not added any preferences");
            }
            else
            {
                var characteristics = JsonConvert.DeserializeObject<List<ViewFoodCharacteristicsResponseDTO>>(serverResponse);
                Console.WriteLine("Id\tCharacteristic");
                foreach (var characteristic in characteristics)
                {
                    Console.WriteLine($"{characteristic.Id}\t{characteristic.Characteristic}");
                }
            }
        }
    }
}
