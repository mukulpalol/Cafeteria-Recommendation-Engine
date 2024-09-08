using AutoMapper;
using CafeteriaRecommendationSystem.Common.DTO.ResponseDTO;
using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;
using CafeteriaRecommendationSystem.Service.ServicesContract;
using Microsoft.Extensions.Logging;

namespace CafeteriaRecommendationSystem.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICharacteristicRepository _characteristicRepository;
        private readonly IUserPreferenceRepository _userPreferenceRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        #region Constructor
        public UserService(IUserRepository userRepository, ICharacteristicRepository characteristicRepository, IUserPreferenceRepository userPreferenceRepository, IMapper mapper, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _characteristicRepository = characteristicRepository;
            _userPreferenceRepository = userPreferenceRepository;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region User CRUD
        public void AddUser(User user)
        {
            _userRepository.Add(user);
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }

        public void DeleteUser(int userId)
        {
            _userRepository.Delete(userId);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetUserById(int userId)
        {
            return _userRepository.GetById(userId);
        }
        #endregion

        #region GetUserPreferences
        public List<ViewFoodCharacteristicsResponseDTO> GetUserPreferences(int userId)
        {
            try
            {
                _logger.LogInformation("GetUserPreferences called");
                var user = _userRepository.GetById(userId);
                var preferenceIds = _userPreferenceRepository.GetAll().Where(e => e.UserId == userId).Select(c => c.CharacteristicId).ToList();
                List<ViewFoodCharacteristicsResponseDTO> preferences = new List<ViewFoodCharacteristicsResponseDTO>();
                foreach (var preferenceId in preferenceIds)
                {
                    ViewFoodCharacteristicsResponseDTO foodPreference = _mapper.Map<ViewFoodCharacteristicsResponseDTO>(_characteristicRepository.GetById(preferenceId));
                    preferences.Add(foodPreference);
                }
                return preferences;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetUserPreferences: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region AddUserPreference
        public string AddUserPreference(int userId, int characteristicId)
        {
            try
            {
                _logger.LogInformation("AddUserPreference called");
                var user = _userRepository.GetById(userId);
                var characteristic = _characteristicRepository.GetById(characteristicId);
                if (characteristic == null)
                {
                    return "Invalid characteristic id";
                }
                var userPreferenceExist = _userPreferenceRepository.GetAll().Where(u => u.UserId == userId && u.CharacteristicId == characteristicId).Any();
                if (!userPreferenceExist)
                {
                    UserPreference userPreference = new UserPreference()
                    {
                        UserId = userId,
                        CharacteristicId = characteristicId
                    };
                    _userPreferenceRepository.Add(userPreference);
                }
                return "Preference added successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in AddUserPreference: {ex.Message}");
                return "Error in adding preference";
            }
        }
        #endregion

        #region DeleteUserPreference
        public string DeleteUserPreference(int userId, int characteristicId)
        {
            try
            {
                _logger.LogInformation("DeleteUserPreference called");
                var user = _userRepository.GetById(userId);
                var characteristic = _characteristicRepository.GetById(characteristicId);
                if (characteristic == null)
                {
                    return "Invalid characteristic id";
                }
                var userPreference = _userPreferenceRepository.GetAll().Where(u => u.UserId == userId && u.CharacteristicId == characteristicId).FirstOrDefault();
                if (userPreference != null)
                {
                    _userPreferenceRepository.Delete(userPreference.Id);
                }
                return "Preference deleted successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in DeleteUserPreference: {ex.Message}");
                return "error in deleting preference";
            }
        }
        #endregion
    }
}
