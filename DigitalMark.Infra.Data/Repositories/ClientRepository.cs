using DigitalMark.Contexts;
using DigitalMark.Domain.Entities;
using DigitalMark.Domain.Interfaces.Repositories;
using DigitalMark.DTO.Queries;
using DigitalMark.DTO.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DigitalMark.Infra.Data.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public IQueryable<Client> Entities { get; set; }

        public ClientRepository(DigitalMarkContext context) : base(context)
        {
            Entities = context.Set<Client>();
        }

        public async Task<IEnumerable<ClientViewModel>> GetAsync(ClientQuery query)
        {
            var entities = Entities;
            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                entities = entities
                    .Where(c => EF.Functions.Like(c.Name, $"%{query.Name}%"));
            }

            if (!string.IsNullOrWhiteSpace(query.Technology))
            {
                entities = entities
                    .Where(c => EF.Functions.Like(c.Technology, $"%{query.Technology}%"));
            }

            return await entities
                .Include(c => c.Project)
                .Select(c => new ClientViewModel()
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    Technology = c.Technology,
                    ProjectName = c.Project.Name,
                })
                .ToListAsync();
        }

        public async Task<ClientViewModel> GetViewModelByAsync(ClientQuery query)
        {
            return await Entities
                .Include(c => c.Project)
                .Where(c => c.Id == query.Id)
                .Select(c => new ClientViewModel()
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    Technology = c.Technology,
                    ProjectId = c.Project.Id.ToString()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<Client> GetByIdAsync(Guid id)
        {
            return await Entities
                .Include(c => c.Project)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}