using CafeteriaRecommendationSystem.Client.OptionCommand;
using System.Net.Sockets;

namespace CafeteriaRecommendationSystem.Client.UserMenu
{
    public class EmployeeMenu : IMenu
    {
        private NetworkStream _stream;
        private int _userId;

        public EmployeeMenu(int userId, NetworkStream stream)
        {
            _stream = stream;
            _userId = userId;
        }
        public void DisplayMenu()
        {
            Console.WriteLine("1. Select menu item for next day menu");
            Console.WriteLine("2. View notifications");
            Console.WriteLine("3. View food characteristics");
            Console.WriteLine("4. View menu");
            Console.WriteLine("5. Submit feedback");
            Console.WriteLine("6. View your selected preferences");
            Console.WriteLine("7. View discarded menu items");
            Console.WriteLine("8. View rolled out menu");
            Console.WriteLine("9. View finalized menu for tomorrow");
            Console.WriteLine("10. Give feedback on discarded menu item");
            Console.WriteLine("11. Update your food preferences");
            Console.WriteLine("0. Logout");
        }

        public ICommand GetCommand(int option)
        {
            return option switch
            {
                1 => new SelectFoodItemForNextDayMenu(_userId, _stream),
                2 => new ViewNotification(_userId, _stream),
                3 => new ViewFoodCharacteristics(_stream),
                4 => new ViewMenu(_stream),
                5 => new SubmitFeedback(_userId, _stream),
                6 => new ViewSelectedPreferences(_userId, _stream),
                7 => new ViewDiscardedMenuItems(_stream),
                8 => new ViewRolledOutMenu(_userId, _stream),
                9 => new ViewFinalizedMenu(_stream),
                10 => new GiveFeedbackOnDiscardedMenuItem(_userId, _stream),
                11 => new UpdateYourFoodPreferences(_userId, _stream),
                0 => null,
                _ => throw new ArgumentException("Invalid option")
            };
        }
    }
}
