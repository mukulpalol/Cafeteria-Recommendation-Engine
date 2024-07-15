using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO.ResponseDTO;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client.OptionCommand
{
    public class ViewFoodCharacteristics : ICommand
    {
        private readonly NetworkStream _stream;

        public ViewFoodCharacteristics(NetworkStream stream)
        {
            _stream = stream;
        }

        public void Execute(RoleEnum role)
        {
            try
            {
                SendViewCharacteristicsRequest(role);
                ReceiveAndDisplayServerResponse();
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

        private void SendViewCharacteristicsRequest(RoleEnum role)
        {
            string optionRequest = $"option|{(int)role}|3";
            byte[] data = Encoding.ASCII.GetBytes(optionRequest);
            _stream.Write(data, 0, data.Length);
        }

        private void ReceiveAndDisplayServerResponse()
        {
            byte[] response = new byte[8192];
            int bytes = _stream.Read(response, 0, response.Length);
            string serverResponse = Encoding.ASCII.GetString(response, 0, bytes);

            var characteristics = JsonConvert.DeserializeObject<List<ViewFoodCharacteristicsResponseDTO>>(serverResponse);

            if (characteristics == null || characteristics.Count == 0)
            {
                Console.WriteLine("No food characteristics available.");
            }
            else
            {
                Console.WriteLine("Id\tCharacteristic");
                foreach (var characteristic in characteristics)
                {
                    Console.WriteLine($"{characteristic.Id}\t{characteristic.Characteristic}");
                }
            }
        }
    }

}
