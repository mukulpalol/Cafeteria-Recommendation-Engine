using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;

namespace CafeteriaRecommendationSystem.DAL.Repositories
{
    public class CharacteristicRepository : Repository<Characteristic>, ICharacteristicRepository
    {
        public CharacteristicRepository(CafeDbContext context) : base(context) { }
    }
}
