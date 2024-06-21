using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;
using CafeteriaRecommendationSystem.Service.ServicesContract;

namespace CafeteriaRecommendationSystem.Service.Services
{
    public class NotificationService : BaseService, INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public void SendNotification(User user, string message)
        {
            var notification = new Notification
            {
                UserId = user.Id,
                Message = message,
                Date = DateTime.Now
            };
            _notificationRepository.Add(notification);
        }

        public List<Notification> GetNotifications(User user)
        {
            return _notificationRepository.GetAll().Where(n => n.UserId == user.Id).ToList();
        }
    }
}
