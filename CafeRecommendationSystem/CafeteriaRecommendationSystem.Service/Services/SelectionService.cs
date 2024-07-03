using CafeteriaRecommendationSystem.Common.DTO.ResponseDTO;
using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;
using CafeteriaRecommendationSystem.Service.ServicesContract;

namespace CafeteriaRecommendationSystem.Service.Services
{
    public class SelectionService : ISelectionService
    {
        private readonly ISelectionRepository _selectionRepository;
        private readonly IMenuItemRepository _menuItemRepository;

        public SelectionService(ISelectionRepository selectionRepository, IMenuItemRepository menuItemRepository)
        {
            _selectionRepository = selectionRepository;
            _menuItemRepository = menuItemRepository;
        }

        public void SelectItem(User user, MenuItem menuItem)
        {
            Selection selection = new Selection();
            selection.UserId = user.Id;
            selection.Date = DateTime.Now;
            selection.MenuItemId = menuItem.Id;
            _selectionRepository.Add(selection);
        }
        public void AddSelection(int userId, int menuItemId)
        {
            Selection selection = new Selection();
            selection.UserId = userId;
            selection.Date = DateTime.Now;
            selection.MenuItemId = menuItemId;
            _selectionRepository.Add(selection);
        }
        public bool CheckSelectionExists(int userId, int menuId)
        {
            var exisitingSelection = _selectionRepository.GetAll().Where(s => s.UserId == userId && s.MenuItemId == menuId && s.Date == DateTime.UtcNow).FirstOrDefault();
            if (exisitingSelection == null)
            {
                return false;
            }
            return true;
        }        
        public List<RolledOutMenuVotesDTO> GetRolledOutMenuVotes()
        {
            var selections = _selectionRepository.GetAll();
            var menuItems = _menuItemRepository.GetAll();

            var result = selections.Where(s => s.Date.Date == DateTime.Today)
                                    .GroupBy(s => s.MenuItemId)
                                    .Select(g => new RolledOutMenuVotesDTO
                                    {
                                        MenuItemId = g.Key,
                                        MenuItemName = menuItems.FirstOrDefault(mi => mi.Id == g.Key).Name,
                                        NumberOfVotes = g.Count()
                                    })
            .ToList();

            return result;
        }
    }
}
