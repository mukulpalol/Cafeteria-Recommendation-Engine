using CafeteriaRecommendationSystem.Common.DTO;
using CafeteriaRecommendationSystem.DAL.Models;

namespace CafeteriaRecommendationSystem.Service.ServicesContract
{
    public interface ISelectionService
    {
        void SelectItem(User user, MenuItem menuItem);
        void AddSelection(int userId, int menuItemId);
        bool CheckSelectionExists(int userId, int menuId);
        public List<RolledOutMenuVotesDTO> GetRolledOutMenuVotes();
    }
}
