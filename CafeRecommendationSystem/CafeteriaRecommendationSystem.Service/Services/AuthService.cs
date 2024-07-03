using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;
using CafeteriaRecommendationSystem.Service.ServicesContract;
using Microsoft.Extensions.Logging;

namespace CafeteriaRecommendationSystem.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<AuthService> logger;
        public AuthService(IUserRepository userRepository, ILogger<AuthService> logger)
        {
            _userRepository = userRepository;
            this.logger = logger;
        }

        public User Login(string email, string password)
        {
            logger.LogInformation("Authenticating user");
            var user = _userRepository.GetAll().FirstOrDefault(u => u.Email == email && u.Password == password);
            return user;
        }
    }
}
