using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;

namespace CafeteriaRecommendationSystem.DAL.Repositories
{
    public class DiscardedMenuItemRepository : Repository<DiscardedMenuItem>, IDiscardedMenuItemRepository
    {
        public DiscardedMenuItemRepository(CafeDbContext context) : base(context) { }
    }
}
