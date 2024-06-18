using CafeteriaRecommendationSystem.DAL.Models;

namespace CafeteriaRecommendationSystem.Service.ServicesContract
{
    public interface IRecommendationService : IBaseService
    {
        List<MenuItem> GetRecommendations(User user);
    }
}