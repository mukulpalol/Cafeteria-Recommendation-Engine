using CafeteriaRecommendationSystem.DAL.Models;

namespace CafeteriaRecommendationSystem.Service.ServicesContract
{
    internal interface IAuthService
    {
        User Login(string email, string password);
    }
}
