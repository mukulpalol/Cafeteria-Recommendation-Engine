using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO.RequestDTO;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client.OptionCommand
{
    public class UpdateYourFoodPreferencesCommand : ICommand
    {
        private readonly int _userId;
        private readonly NetworkStream _stream;
        public UpdateYourFoodPreferencesCommand(int userId, NetworkStream stream)
        {
            _stream = stream;
            _userId = userId;
        }

        public void Execute(RoleEnum role)
        {
            UpdateFoodPreferenceRequestDTO request = new UpdateFoodPreferenceRequestDTO();
            Console.WriteLine("1. Add preference");
            Console.WriteLine("2. Delete preference");
            Console.Write("Enter your choice: ");
            request.Choice = int.Parse(Console.ReadLine());

            Console.Write("Enter characteristic id: ");
            request.CharacteristicId = int.Parse(Console.ReadLine());

            request.UserId = _userId;
            string requestJson = JsonConvert.SerializeObject(request);

            string optionRequest = $"option|{(int)role}|11|{requestJson}";
            byte[] data = Encoding.ASCII.GetBytes(optionRequest);
            _stream.Write(data, 0, data.Length);

            byte[] response = new byte[8192];
            int bytes = _stream.Read(response, 0, response.Length);
            string serverResponse = Encoding.ASCII.GetString(response, 0, bytes);
            Console.WriteLine($"\nServer response: {serverResponse}\n");
        }
    }
}
