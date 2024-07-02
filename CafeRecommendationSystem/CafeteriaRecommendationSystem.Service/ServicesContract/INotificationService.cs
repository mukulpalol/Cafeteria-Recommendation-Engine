using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.DAL.Models;

namespace CafeteriaRecommendationSystem.Service.ServicesContract
{
    public interface INotificationService : IBaseService
    {
        void SendNotification(NotificationTypeEnum notificationType, string message);        
        List<Notification> GetNotifications(User user);
    }
}