using CafeteriaRecommendationSystem.DAL.Models;

namespace CafeteriaRecommendationSystem.Service.ServicesContract
{
    public interface IUserService : IBaseService
    {
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        IEnumerable<User> GetAllUsers();
        User GetUserById(int userId);
    }
}
