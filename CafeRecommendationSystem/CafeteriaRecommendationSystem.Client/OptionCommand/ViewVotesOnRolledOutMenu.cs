using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO;
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
            string optionRequest = $"option|{(int)role}|5";
            byte[] data = Encoding.ASCII.GetBytes(optionRequest);
            _stream.Write(data, 0, data.Length);

            byte[] response = new byte[8192];
            int bytes = _stream.Read(response, 0, response.Length);
            string serverResponse = Encoding.ASCII.GetString(response, 0, bytes);
            var menuVoteResponse = JsonConvert.DeserializeObject<List<RolledOutMenuVotesDTO>>(serverResponse);

            Console.WriteLine("Menu Item Id\tName\tNumber Of Votes\n");
            foreach (var voteResponse in menuVoteResponse)
            {
                Console.WriteLine($"{voteResponse.MenuItemId}\t{voteResponse.MenuItemName}\t{voteResponse.NumberOfVotes}\n");
            }
        }
    }
}
