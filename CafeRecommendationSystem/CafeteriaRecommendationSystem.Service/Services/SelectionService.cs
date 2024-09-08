using CafeteriaRecommendationSystem.Common.DTO.ResponseDTO;
using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;
using CafeteriaRecommendationSystem.Service.ServicesContract;
using Microsoft.Extensions.Logging;

namespace CafeteriaRecommendationSystem.Service.Services
{
    public class SelectionService : ISelectionService
    {
        private readonly ISelectionRepository _selectionRepository;
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly ILogger<SelectionService> _logger;

        #region Constructor
        public SelectionService(ISelectionRepository selectionRepository, IMenuItemRepository menuItemRepository, ILogger<SelectionService> logger)
        {
            _selectionRepository = selectionRepository;
            _menuItemRepository = menuItemRepository;
            _logger = logger;
        }
        #endregion

        #region SelectItem
        public void SelectItem(User user, MenuItem menuItem)
        {
            try
            {
                _logger.LogInformation("SelectItem called");
                Selection selection = new Selection();
                selection.UserId = user.Id;
                selection.Date = DateTime.Now;
                selection.MenuItemId = menuItem.Id;
                _selectionRepository.Add(selection);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in SelectItem: {ex.Message}");
            }
        }
        #endregion

        #region AddSelection
        public void AddSelection(int userId, int menuItemId)
        {
            try
            {
                _logger.LogInformation("AddSelection called");
                Selection selection = new Selection();
                selection.UserId = userId;
                selection.Date = DateTime.Now;
                selection.MenuItemId = menuItemId;
                _selectionRepository.Add(selection);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in AddSelection: {ex.Message}");
            }
        }
        #endregion

        #region CheckSelectionExists
        public bool CheckSelectionExists(int userId, int menuId)
        {
            try
            {
                _logger.LogInformation("CheckSelectionExists called");
                var exisitingSelection = _selectionRepository.GetAll().Where(s => s.UserId == userId && s.MenuItemId == menuId && s.Date.Date == DateTime.Today).FirstOrDefault();
                if (exisitingSelection == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in CheckSelectionExists: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region GetRolledOutMenuVotes
        public List<RolledOutMenuVotesDTO> GetRolledOutMenuVotes()
        {
            try
            {
                _logger.LogInformation("GetRolledOutMenuVotes called");
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
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetRolledOutMenuVotes: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
