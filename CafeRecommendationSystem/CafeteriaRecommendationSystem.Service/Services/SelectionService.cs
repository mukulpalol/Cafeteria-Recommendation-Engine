using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;
using CafeteriaRecommendationSystem.Service.ServicesContract;

namespace CafeteriaRecommendationSystem.Service.Services
{
    public class SelectionService : BaseService, ISelectionService
    {
        private readonly ISelectionRepository _selectionRepository;

        public SelectionService(ISelectionRepository selectionRepository)
        {
            _selectionRepository = selectionRepository;
        }

        public void SelectItem(User user, Selection selection)
        {
            EnsureRole(user, RoleEnum.Employee);
            selection.UserId = user.Id;
            selection.Date = DateTime.Now;
            _selectionRepository.Add(selection);
        }
    }
}
