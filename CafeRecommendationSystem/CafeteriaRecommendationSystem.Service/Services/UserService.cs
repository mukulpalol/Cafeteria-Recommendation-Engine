using CafeteriaRecommendationSystem.Common.DTO.ResponseDTO;
using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;
using CafeteriaRecommendationSystem.Service.ServicesContract;

namespace CafeteriaRecommendationSystem.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICharacteristicRepository _characteristicRepository;
        private readonly IUserPreferenceRepository _userPreferenceRepository;

        public UserService(IUserRepository userRepository, ICharacteristicRepository characteristicRepository, IUserPreferenceRepository userPreferenceRepository)
        {
            _userRepository = userRepository;
            _characteristicRepository = characteristicRepository;
            _userPreferenceRepository = userPreferenceRepository;
        }

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

        public List<ViewFoodCharacteristicsResponseDTO> GetUserPreferences(int userId)
        {
            var user = _userRepository.GetById(userId);
            var preferenceIds = _userPreferenceRepository.GetAll().Where(e => e.UserId == userId).Select(c => c.CharacteristicId).ToList();
            List<ViewFoodCharacteristicsResponseDTO> preferences = new List<ViewFoodCharacteristicsResponseDTO>();
            foreach (var preferenceId in preferenceIds)
            {
                Characteristic preference = _characteristicRepository.GetById(preferenceId);
                ViewFoodCharacteristicsResponseDTO foodPreference = new ViewFoodCharacteristicsResponseDTO() { Id = preference.Id, Characteristic = preference.Name };
                preferences.Add(foodPreference);
            }
            return preferences;
        }

        public string AddUserPreference(int userId, int characteristicId)
        {
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

        public string DeleteUserPreference(int userId, int characteristicId)
        {
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
    }
}
