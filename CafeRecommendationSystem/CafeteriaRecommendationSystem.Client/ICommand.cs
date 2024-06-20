using CafeteriaRecommendationSystem.Common;

namespace CafeteriaRecommendationSystem.Client
{
    public interface ICommand
    {
        void Execute(RoleEnum role);
    }
}
