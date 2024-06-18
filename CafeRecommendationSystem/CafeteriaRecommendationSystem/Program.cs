using CafeteriaRecommendationSystem.DAL.Repositories;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;
using CafeteriaRecommendationSystem.Service.Services;
using CafeteriaRecommendationSystem.Service.ServicesContract;
using Microsoft.Extensions.DependencyInjection;

namespace CafeteriaRecommendationSystem
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IFeedbackRepository, FeedbackRepository>()
                .AddScoped<IMenuItemRepository, MenuItemRepository>()
                .AddScoped<INotificationRepository, NotificationRepository>()
                .AddScoped<IRecommendationRepository, RecommendationRepository>()
                .AddScoped<ISelectionRepository, SelectionRepository>()
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<IBaseService, BaseService>()
                .AddScoped<IFeedbackService, FeedbackService>()
                .AddScoped<IMenuItemService, MenuItemService>()
                .AddScoped<INotificationService, NotificationService>()
                .AddScoped<IRecommendationService, RecommendationService>()
                .AddScoped<ISelectionService, SelectionService>()
                .AddScoped<IUserService, UserService>()
                .BuildServiceProvider();

            var server = new Server("127.0.0.1", 5000, serviceProvider);
            await server.StartAsync();
        }
    }
}
