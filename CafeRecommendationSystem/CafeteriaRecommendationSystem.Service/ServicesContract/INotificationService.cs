using CafeteriaRecommendationSystem.DAL.Models;

namespace CafeteriaRecommendationSystem.Service.ServicesContract
{
    public interface INotificationService : IBaseService
    {
        void SendNotification(User user, string message);
        List<Notification> GetNotifications(User user);
    }
}