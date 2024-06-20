using CafeteriaRecommendationSystem.Common;
using System.Net.Sockets;

namespace CafeteriaRecommendationSystem.Client.OptionCommand
{
    internal class RollOutMenuCommand : ICommand
    {
        private NetworkStream _stream;
        public RollOutMenuCommand(NetworkStream stream)
        {
            _stream = stream;
        }

        public void Execute(RoleEnum role)
        {
            
        }
    }
}
