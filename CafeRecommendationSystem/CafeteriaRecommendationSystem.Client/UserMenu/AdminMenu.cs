using CafeteriaRecommendationSystem.Client.OptionCommand;
using System.Net.Sockets;

namespace CafeteriaRecommendationSystem.Client.UserMenu
{
    public class AdminMenu : IMenu
    {
        private NetworkStream _stream;
        private int _userId;

        public AdminMenu(int userId, NetworkStream stream)
        {
            _userId = userId;
            _stream = stream;
        }

        public void DisplayMenu()
        {
            Console.WriteLine("1. Add menu item");
            Console.WriteLine("2. Update menu item");
            Console.WriteLine("3. Delete menu item");
            Console.WriteLine("4. View menu");
            Console.WriteLine("0. Logout");
        }

        public ICommand GetCommand(int option)
        {
            return option switch
            {
                1 => new AddMenuItemCommand(_stream),
                2 => new UpdateMenuItemCommand(_stream),
                3 => new DeleteMenuItemCommand(_stream),
                4 => new ViewMenuCommand(_stream),
                0 => null,
                _ => throw new ArgumentException("Invalid option")
            };
        }
    }
}
