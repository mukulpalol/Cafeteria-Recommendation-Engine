using CafeteriaRecommendationSystem.Client.OptionCommand;
using System.Net.Sockets;

namespace CafeteriaRecommendationSystem.Client
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
            Console.WriteLine("1. Select breakfast item for next day menu");
            Console.WriteLine("2. Select lunch item for next day menu");
            Console.WriteLine("3. Select dinner item for next day menu");
            Console.WriteLine("4. View menu");
            Console.WriteLine("5. Submit feedback");
            Console.WriteLine("6. View notifications");
            Console.WriteLine("0. Logout");
        }

        public ICommand GetCommand(int option)
        {
            return option switch
            {
                1 => new SelectFoodItemForNextDayMenuCommand(_userId, _stream, Common.MenuItemTypeEnum.Breakfast),
                2 => new SelectFoodItemForNextDayMenuCommand(_userId, _stream, Common.MenuItemTypeEnum.Lunch),
                3 => new SelectFoodItemForNextDayMenuCommand(_userId, _stream, Common.MenuItemTypeEnum.Dinner),
                4 => new ViewMenuCommand(_stream),
                5 => new SubmitFeedbackCommand(_userId, _stream),
                0 => null,
                _ => throw new ArgumentException("Invalid option")
            };
        }
    }
}
