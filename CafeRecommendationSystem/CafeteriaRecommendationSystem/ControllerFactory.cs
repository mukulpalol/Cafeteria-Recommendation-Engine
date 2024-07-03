using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Contollers;

namespace CafeteriaRecommendationSystem
{
    public static class ControllerFactory
    {
        public static BaseController GetController(int role, IServiceProvider serviceProvider)
        {
            switch (role)
            {
                case (int)RoleEnum.Admin:
                    return new AdminController(serviceProvider);
                case (int)RoleEnum.Chef:
                    return new ChefController(serviceProvider);
                case (int)RoleEnum.Employee:
                    return new EmployeeController(serviceProvider);
                default:
                    throw new ArgumentException("Invalid role");
            }
        }
    }
}
