using DigitalMark.Contexts;
using DigitalMark.Domain.Interfaces;

namespace DigitalMark.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DigitalMarkContext _context;

        public UnitOfWork(DigitalMarkContext context) 
        {
            _context = context;
        }
        
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}