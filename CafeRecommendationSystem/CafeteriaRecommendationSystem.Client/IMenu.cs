namespace CafeteriaRecommendationSystem.Client
{
    public interface IMenu
    {
        void DisplayMenu();
        ICommand GetCommand(int option);
    }
}
