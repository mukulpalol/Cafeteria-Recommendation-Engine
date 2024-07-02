using CafeteriaRecommendationSystem.Common;
using System.Net.Sockets;

namespace CafeteriaRecommendationSystem.Client.OptionCommand
{
    public class GiveFeedbackOnDiscardedMenuItemCommand : ICommand
    {
        private readonly NetworkStream _stream;
        private readonly int _userId;
        public GiveFeedbackOnDiscardedMenuItemCommand(int userId, NetworkStream stream)
        {
            _userId = userId;
            _stream = stream;
        }

        public void Execute(RoleEnum role)
        {
            //TODO from here
        }
    }
}
