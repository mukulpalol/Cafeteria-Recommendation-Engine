using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.Repositories;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;
using CafeteriaRecommendationSystem.Service.ServicesContract;

namespace CafeteriaRecommendationSystem.Service.Services
{
    public class RecommendationService : BaseService, IRecommendationService
    {        
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMenuItemRepository _menuItemRepository;

        public RecommendationService(IFeedbackRepository feedbackRepository, IMenuItemRepository menuItemRepository)
        {            
            _feedbackRepository = feedbackRepository;
            _menuItemRepository = menuItemRepository;
        }

        public List<MenuItem> GetRecommendations(User user)
        {
            var lastWeekDate = DateTime.Now.AddDays(-7);
            var feedbacks = _feedbackRepository.GetAll()
                .Where(f => f.Date >= lastWeekDate)
                .GroupBy(f => f.MenuItemId)
                .Select(group => new
                {
                    MenuItemId = group.Key,
                    AverageRating = group.Average(f => f.Rating)
                })
                .OrderByDescending(g => g.AverageRating)
                .Take(5)
                .Select(g => g.MenuItemId)
            .ToList();

            return _menuItemRepository.GetAll().Where(mi => feedbacks.Contains(mi.Id)).ToList();
        }

    }
}
