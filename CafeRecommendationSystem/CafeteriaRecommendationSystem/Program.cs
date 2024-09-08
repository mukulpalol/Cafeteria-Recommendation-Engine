using CafeteriaRecommendationSystem.DAL;
using CafeteriaRecommendationSystem.DAL.Profiles;
using CafeteriaRecommendationSystem.DAL.Repositories;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;
using CafeteriaRecommendationSystem.Service.Services;
using CafeteriaRecommendationSystem.Service.ServicesContract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem
{
    public class Program
    {
        private static TcpListener _listener;
        private static IServiceProvider _serviceProvider;

        public static async Task Main(string[] args)
        {
            var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            try
            {
                var configuration = new ConfigurationBuilder()
                                     .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                     .AddJsonFile("appsettings.json")
                                     .Build();

                var services = new ServiceCollection();
                ConfigureServices(services, configuration);

                _serviceProvider = services.BuildServiceProvider();

                StartServer(logger);
            }
            catch (Exception exception)
            {
                logger.Error(exception, "Stopped program because of exception");
                throw new Exception(exception.Message);
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CafeDbContext>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IMenuItemRepository, MenuItemRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IRecommendationRepository, RecommendationRepository>();
            services.AddScoped<ISelectionRepository, SelectionRepository>();
            services.AddScoped<IDiscardedMenuItemRepository, DiscardedMenuItemRepository>();
            services.AddScoped<IDiscardedMenuItemFeedbackRepository, DiscardedMenuItemFeedbackRepository>();
            services.AddScoped<ICharacteristicRepository, CharacteristicRepository>();
            services.AddScoped<IMenuItemCharacteristicRpository, MenuItemCharacteristicRpository>();
            services.AddScoped<IUserPreferenceRepository, UserPreferenceRepository>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IMenuItemService, MenuItemService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IRecommendationService, RecommendationService>();
            services.AddScoped<ISelectionService, SelectionService>();
            services.AddScoped<ISentimentAnalysisHelper, SentimentAnalysisHelper>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDiscardedMenuItemService, DiscardedMenuItemService>();
            
            services.AddAutoMapper(typeof(MenuProfile));
            services.AddAutoMapper(typeof(FeedbackProfile));
            services.AddAutoMapper(typeof(CharacteristicProfile));

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                loggingBuilder.AddNLog(configuration);
            });
        }

        private static void StartServer(Logger logger)
        {
            _listener = new TcpListener(IPAddress.Any, 8888);
            _listener.Start();
            Console.WriteLine("Server started on port 8888.");
            logger.Info("Server started on port 8888.");

            while (true)
            {
                TcpClient client = _listener.AcceptTcpClient();
                logger.Info($"New client connected: {client.Client.RemoteEndPoint}");
                Thread clientThread = new Thread(() => HandleClient(client, logger));
                clientThread.Start();
            }
        }

        private static void HandleClient(TcpClient client, Logger logger)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[8192];
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                string request = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                string response = RequestProcessor.ProcessRequest(request, _serviceProvider);
                byte[] responseBytes = Encoding.ASCII.GetBytes(response);
                stream.Write(responseBytes, 0, responseBytes.Length);
            }

            logger.Info($"Client {client.Client.RemoteEndPoint} disconnected");
            client.Close();
        }
    }
}
