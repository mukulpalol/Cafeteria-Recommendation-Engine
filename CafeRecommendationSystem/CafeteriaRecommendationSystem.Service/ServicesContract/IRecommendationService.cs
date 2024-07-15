using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO.ResponseDTO;
using CafeteriaRecommendationSystem.DAL.Models;

namespace CafeteriaRecommendationSystem.Service.ServicesContract
{
    public interface IRecommendationService
    {
        List<MenuItemResponseDTO> GetRecommendations(int numberOfRecommendations, MenuItemTypeEnum menuItemType);        
        void RollOutMenu(List<int> menuItemIdList);
        string FinaliseMenu(List<int> menuItemIdList);
        void UpdateRecommendation(Recommendation recommendation);
        Recommendation GetRecommendationByMenuItem(int menuItemId);        
    }
}