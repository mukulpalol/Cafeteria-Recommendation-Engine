using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;
using CafeteriaRecommendationSystem.Service.ServicesContract;
using Microsoft.Extensions.Logging;

namespace CafeteriaRecommendationSystem.Service.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<NotificationService> _logger;

        #region Constructor
        public NotificationService(INotificationRepository notificationRepository, IUserRepository userRepository, ILogger<NotificationService> logger)
        {
            _notificationRepository = notificationRepository;
            _userRepository = userRepository;
            _logger = logger;
        }
        #endregion

        #region SendNotification
        public void SendNotification(NotificationTypeEnum notificationType, string message)
        {
            try
            {
                _logger.LogInformation("SendNotification called");
                var users = _userRepository.GetAll().Where(u => u.RoleId == (int)RoleEnum.Employee).ToList();
                foreach (var user in users)
                {
                    var notification = new Notification
                    {
                        UserId = user.Id,
                        Message = message,
                        Date = DateTime.Now,
                        NotificationTypeId = (int)notificationType,
                        IsDelivered = false
                    };
                    _notificationRepository.Add(notification);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in SendNotification: {ex.Message}");
            }
        }
        #endregion

        #region GetNotifications
        public List<Notification> GetNotifications(int userId)
        {
            try
            {
                _logger.LogInformation("GetNotifications called");
                var notifications = _notificationRepository.GetAll().Where(n => n.UserId == userId && n.Date.Date == DateTime.Today && n.IsDelivered == false).ToList();
                foreach (var notification in notifications)
                {
                    notification.IsDelivered = true;
                    _notificationRepository.Update(notification);
                }
                return notifications.DistinctBy(n=>n.Message).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetNotifications: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
