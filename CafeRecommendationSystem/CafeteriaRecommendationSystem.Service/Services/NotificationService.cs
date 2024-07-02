using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;
using CafeteriaRecommendationSystem.Service.ServicesContract;

namespace CafeteriaRecommendationSystem.Service.Services
{
    public class NotificationService : BaseService, INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IUserRepository _userRepository;

        public NotificationService(INotificationRepository notificationRepository, IUserRepository userRepository)
        {
            _notificationRepository = notificationRepository;
            _userRepository = userRepository;
        }
        public void SendNotification(NotificationTypeEnum notificationType, string message)
        {
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

        public List<Notification> GetNotifications(User user)
        {
            return _notificationRepository.GetAll().Where(n => n.UserId == user.Id).ToList();
        }
    }
}
