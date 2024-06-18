using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.DAL.Models;

namespace CafeteriaRecommendationSystem.Service.ServicesContract
{
    public interface IBaseService
    {
        void EnsureRole(User user, RoleEnum role);
    }
}