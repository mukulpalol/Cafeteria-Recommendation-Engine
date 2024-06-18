using CafeteriaRecommendationSystem.DAL.Models;

namespace CafeteriaRecommendationSystem.Service.ServicesContract
{
    public interface ISelectionService : IBaseService
    {
        void SelectItem(User user, Selection selection);
    }
}
