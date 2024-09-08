using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO.ResponseDTO;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client.OptionCommand
{
    public class ViewVotesOnRolledOutMenu : ICommand
    {
        private NetworkStream _stream;

        public ViewVotesOnRolledOutMenu(NetworkStream stream)
        {
            _stream = stream;
        }

        public void Execute(RoleEnum role)
        {
            try
            {
                SendViewVotesRequest(role);
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

        private void SendViewVotesRequest(RoleEnum role)
        {
            string optionRequest = $"option|{(int)role}|5";
            byte[] data = Encoding.ASCII.GetBytes(optionRequest);
            _stream.Write(data, 0, data.Length);
        }

        private void ReceiveAndDisplayServerResponse()
        {
            byte[] response = new byte[8192];
            int bytes = _stream.Read(response, 0, response.Length);
            string serverResponse = Encoding.ASCII.GetString(response, 0, bytes);

            var menuVoteResponse = JsonConvert.DeserializeObject<List<RolledOutMenuVotesDTO>>(serverResponse);
            if (menuVoteResponse == null)
            {
                throw new JsonSerializationException("Deserialization returned null.");
            }

            Console.WriteLine("Menu Item Id\tName\tNumber Of Votes\n");
            foreach (var voteResponse in menuVoteResponse)
            {
                Console.WriteLine($"{voteResponse.MenuItemId}\t{voteResponse.MenuItemName}\t{voteResponse.NumberOfVotes}\n");
            }
        }
    }

}
