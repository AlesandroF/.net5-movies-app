using System.Linq;
using System.Threading.Tasks;
using Infra.Context;
using Infra.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.Base
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly MoviesContext _context;

        protected Repository(MoviesContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
            => (await _context.GetDbSet<TEntity>().AddAsync(entity)).Entity;

        public virtual async Task DeleteAsync(int id)
        {
            var element = await GetByIdAsync(id);
            _context.Set<TEntity>().Remove(element);
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
            => await _context.GetDbSet<TEntity>().FindAsync(id);

        public virtual async Task UpdateAsync(TEntity entity, int id)
        {
            if (entity == null) return;
            var existing = await GetByIdAsync(id);

            if (existing != null)
                _context.Entry(existing).CurrentValues.SetValues(entity);
        }

        protected virtual IQueryable<TEntity> Query()
            => _context.GetDbSet<TEntity>().AsNoTracking().AsQueryable();
    }
}