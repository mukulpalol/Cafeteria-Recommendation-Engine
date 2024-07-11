using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.DAL.Models;

namespace CafeteriaRecommendationSystem.Service.ServicesContract
{
    public interface INotificationService
    {
        void SendNotification(NotificationTypeEnum notificationType, string message);
        List<Notification> GetNotifications(int userId);
    }
}