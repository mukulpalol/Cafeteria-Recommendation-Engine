using CafeteriaRecommendationSystem.Client.OptionCommand;
using System.Net.Sockets;

namespace CafeteriaRecommendationSystem.Client
{
    public class ChefMenu : IMenu
    {
        private NetworkStream _stream;
        private int _userId;

        public ChefMenu(int userId, NetworkStream stream)
        {
            _userId = userId;
            _stream = stream;
        }

        public void DisplayMenu()
        {
            Console.WriteLine("1. Get recommendation");
            Console.WriteLine("2. Role out menu for next day");
            Console.WriteLine("3. Finalise menu for next day");
            Console.WriteLine("4. View menu");
            Console.WriteLine("5. View votes on rolled out menu items");            
            Console.WriteLine("6. Generate discarded menu items");
            Console.WriteLine("7. View discarded menu items");
            Console.WriteLine("8. Handle discarded menu items");
            // Console.WriteLine("9. Generate monthly report");
            Console.WriteLine("0. Logout");
        }

        public ICommand GetCommand(int option)
        {
            return option switch
            {
                1 => new GetRecommendationCommand(_stream),
                2 => new RollOutMenuCommand(_stream),
                3 => new FinaliseMenuCommand(_stream),
                4 => new ViewMenuCommand(_stream),
                5 => new ViewVotesOnRolledOutMenu(_stream),
                6 => new GenerateDiscardedMenuItemsCommand(_stream),
                7 => new ViewDiscardedMenuItemsCommand(_stream),
                8 => new HandleDiscardMenuItemsCommand(_stream),
                0 => null,
                _ => throw new ArgumentException("Invalid option")
            };
        }
    }
}
