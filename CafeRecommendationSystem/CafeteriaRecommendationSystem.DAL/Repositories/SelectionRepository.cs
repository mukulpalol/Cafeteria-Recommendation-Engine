using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;

namespace CafeteriaRecommendationSystem.DAL.Repositories
{
    public class SelectionRepository : Repository<Selection>, ISelectionRepository
    {
        public SelectionRepository(CafeDbContext context) : base(context) { }
    }
}
