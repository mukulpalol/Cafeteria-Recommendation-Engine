using CafeteriaRecommendationSystem.DAL.RepositoriesContract;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaRecommendationSystem.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly CafeDbContext _context;
        public Repository(CafeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
