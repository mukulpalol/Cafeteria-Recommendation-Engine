using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;

namespace CafeteriaRecommendationSystem.DAL.Repositories
{
    public class MenuItemCharacteristicRpository : Repository<MenuItemCharacteristic>, IMenuItemCharacteristicRpository
    {
        public MenuItemCharacteristicRpository(CafeDbContext context) : base(context) { }
    }
}
