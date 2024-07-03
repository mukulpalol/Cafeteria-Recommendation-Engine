using CafeteriaRecommendationSystem.DAL.Models;

namespace CafeteriaRecommendationSystem.Service.ServicesContract
{
    public interface IUserService
    {
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        IEnumerable<User> GetAllUsers();
        User GetUserById(int userId);
        List<Characteristic> GetUserPreferences(int userId);
        string AddUserPreference(int userId, int characteristicId);
        string DeleteUserPreference(int userId, int characteristicId);
    }
}
