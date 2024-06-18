using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.Service.ServicesContract;

namespace CafeteriaRecommendationSystem.Service.Services
{
    public class BaseService : IBaseService
    {
        public void EnsureRole(User user, RoleEnum role)
        {

            if (user.RoleId != (int)role)
            {
                throw new UnauthorizedAccessException("User does not have the required role.");
            }
        }
    }
}
