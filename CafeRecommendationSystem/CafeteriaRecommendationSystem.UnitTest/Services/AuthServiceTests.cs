using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;
using CafeteriaRecommendationSystem.Service.Services;
using CafeteriaRecommendationSystem.Service.ServicesContract;
using Microsoft.Extensions.Logging;
using Moq;

namespace CafeteriaRecommendationSystem.UnitTest.Services
{
    [TestFixture]
    public class AuthServiceTests
    {
        private IAuthService _authService;
        private Mock<ILogger<AuthService>> mockLogger;
        private Mock<IUserRepository> mockUserRepository;

        [SetUp]
        public void Setup()
        {
            mockLogger = new Mock<ILogger<AuthService>>();
            mockUserRepository = new Mock<IUserRepository>();
        }

        [Test]
        public void Login_ValidCredentials_ReturnsUser()
        {
            var testUser = new User { Id = 1, Email = "test@email.com", Password = "Password@1" };
            mockUserRepository.Setup(repo => repo.GetAll()).Returns(new[] { testUser }.AsQueryable());

            _authService = new AuthService(mockUserRepository.Object, mockLogger.Object);

            var result = _authService.Login("test@email.com", "Password@1");

            Assert.NotNull(result);
            Assert.AreEqual(testUser.Id, result.Id);
            Assert.AreEqual(testUser.Email, result.Email);
            Assert.AreEqual(testUser.Password, result.Password);
        }

        [Test]
        public void Login_InvalidCredentials_ReturnsNull()
        {
            _authService = new AuthService(mockUserRepository.Object, mockLogger.Object);

            var result = _authService.Login("test@email.com", "wrongpassword");

            Assert.Null(result);
        }
    }
}
