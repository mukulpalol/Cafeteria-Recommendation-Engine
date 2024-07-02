using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO;
using CafeteriaRecommendationSystem.DAL.Models;

namespace CafeteriaRecommendationSystem.Service.ServicesContract
{
    public interface IRecommendationService : IBaseService
    {
        List<MenuItemResponseDTO> GetRecommendations(int numberOfRecommendations, MenuItemTypeEnum menuItemType);
        void AddRecommendation(Recommendation recommendation);
        void RollOutMenu(List<int> menuItemIdList);
        string FinaliseMenu(List<int> menuItemIdList);
        void UpdateRecommendation(Recommendation recommendation);
        Recommendation GetRecommendationByMenuItem(int menuItemId);
        bool CheckMenuItemWasFinalised(int menuItemId);
    }
}