using DigitalMark.Contexts;
using DigitalMark.Domain.Entities;
using DigitalMark.Domain.Interfaces.Repositories;

namespace DigitalMark.Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        private DigitalMarkContext _context;
        
        public BaseRepository(DigitalMarkContext context)
        {
            _context = context;
        }

        public virtual async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

        public virtual void RemoveAsync(T entity)
        {
            _context.Remove(entity);
        }

        public virtual void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}