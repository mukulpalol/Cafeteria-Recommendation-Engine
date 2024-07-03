using CafeteriaRecommendationSystem.DAL.Models;

namespace CafeteriaRecommendationSystem.DAL.RepositoriesContract
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
    public interface IUserRepository : IRepository<User> { }
    public interface IMenuItemRepository : IRepository<MenuItem> { }
    public interface IFeedbackRepository : IRepository<Feedback> { }
    public interface IRecommendationRepository : IRepository<Recommendation> { }
    public interface INotificationRepository : IRepository<Notification> { }
    public interface ISelectionRepository : IRepository<Selection> { }
    public interface IDiscardedMenuItemRepository : IRepository<DiscardedMenuItem> { }
    public interface IDiscardedMenuItemFeedbackRepository : IRepository<DiscardedMenuItemFeedback> { }
    public interface ICharacteristicRepository : IRepository<Characteristic> { }
    public interface IMenuItemCharacteristicRpository : IRepository<MenuItemCharacteristic> { }
    public interface IUserPreferenceRepository : IRepository<UserPreference> { }
}
