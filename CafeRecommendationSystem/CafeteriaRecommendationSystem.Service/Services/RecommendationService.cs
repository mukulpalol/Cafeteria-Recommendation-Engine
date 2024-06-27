using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO;
using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;
using CafeteriaRecommendationSystem.Service.ServicesContract;

namespace CafeteriaRecommendationSystem.Service.Services
{
    public class RecommendationService : BaseService, IRecommendationService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IRecommendationRepository _recommendationRepository;

        public RecommendationService(IFeedbackRepository feedbackRepository, IMenuItemRepository menuItemRepository, IRecommendationRepository recommendationRepository)
        {
            _feedbackRepository = feedbackRepository;
            _menuItemRepository = menuItemRepository;
            _recommendationRepository = recommendationRepository;
        }

        public List<MenuItemResponseDTO> GetRecommendations(int numberOfRecommendations, MenuItemTypeEnum menuItemType)
        {
            var lastWeekDate = DateTime.Now.AddDays(-7);

            var menuItems = _menuItemRepository.GetAll()
                .Where(mi => mi.TypeId == (int)menuItemType && mi.AvailabilityStatusId == 1)
                .ToList();

            var menuItemIds = menuItems.Select(mi => mi.Id).ToList();

            var feedbacks = _feedbackRepository.GetAll()
                .Where(f => f.Date <= lastWeekDate && menuItemIds.Contains(f.MenuItemId))
                .GroupBy(f => f.MenuItemId)
                .Select(group => new
                {
                    MenuItemId = group.Key,
                    AverageRating = group.Average(f => f.Rating)
                })
                .ToList();

            var recommendations = menuItems
                .Join(feedbacks, mi => mi.Id, f => f.MenuItemId, (mi, f) => new
                {
                    MenuItem = mi,
                    AverageRating = f.AverageRating
                })
                .OrderByDescending(item => item.AverageRating)
                .ThenByDescending(item => item.MenuItem.SentimentScore)
                .Take(numberOfRecommendations)
                .Select(item => item.MenuItem)
                .ToList();

            List<MenuItemResponseDTO> responses = new List<MenuItemResponseDTO>();
            foreach (var menuItem in recommendations)
            {
                MenuItemResponseDTO menuItemResponse = new MenuItemResponseDTO();
                menuItemResponse.Id = menuItem.Id;
                menuItemResponse.Name = menuItem.Name;
                menuItemResponse.Price = menuItem.Price;
                menuItemResponse.Type = ((MenuItemTypeEnum)menuItem.TypeId).ToString();
                menuItemResponse.Availability = ((AvailabilityStatusEnum)menuItem.AvailabilityStatusId).ToString();
                menuItemResponse.GeneralSentiment = menuItem.GeneralSentiment;
                menuItemResponse.SentimentScore = menuItem.SentimentScore;
                responses.Add(menuItemResponse);
            }

            return responses;
        }

        public void AddRecommendation(Recommendation recommendation)
        {
            bool alreadyExists = _recommendationRepository.GetAll().Any(r => r.MenuItemId == recommendation.MenuItemId && r.RecommendationDate.Date == recommendation.RecommendationDate);
            if (!alreadyExists)
            {
                _recommendationRepository.Add(recommendation);

            }
        }

        public void UpdateRecommendation(Recommendation recommendation)
        {
            _recommendationRepository.Update(recommendation);
        }

        public Recommendation GetRecommendationByMenuItem(int menuItemId)
        {
            var recommendation = _recommendationRepository.GetAll().Where(e => e.MenuItemId == menuItemId && e.RecommendationDate == DateTime.UtcNow).FirstOrDefault();
            return recommendation;
        }
    }
}
