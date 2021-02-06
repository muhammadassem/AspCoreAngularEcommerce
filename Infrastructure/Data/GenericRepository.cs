using Core.Entities;
using Core.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _dbContext;
        public GenericRepository(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual IQueryable<T> GetAll()
        {
            return  _dbContext.Set<T>().AsQueryable();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

    }
}
