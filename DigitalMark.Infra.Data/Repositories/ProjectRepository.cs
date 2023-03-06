using DigitalMark.Contexts;
using DigitalMark.Domain.Entities;
using DigitalMark.Domain.Interfaces.Repositories;
using DigitalMark.DTO.Queries;
using DigitalMark.DTO.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DigitalMark.Infra.Data.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public IQueryable<Project> Entities { get; set; }

        public ProjectRepository(DigitalMarkContext context) : base(context)
        {
            Entities = context.Set<Project>();
        }

        public async Task<IEnumerable<ProjectViewModel>> GetAsync(ProjectQuery query)
        {
            var entities = Entities;
            
            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                entities = entities
                    .Where(p => EF.Functions.Like(p.Name, $"%{query.Name}%"));
            }

            return await entities
                .Include(p => p.Client)
                .Select(p => new ProjectViewModel()
                {
                    Id = p.Id.ToString(),
                    Name = p.Name,
                    ClientName = p.Client.Name,
                    ClientTechnology = p.Client.Technology,
                })
                .ToListAsync();
        }

        public async Task<ProjectViewModel> GetViewModelByAsync(ProjectQuery query)
        {
            return await Entities
                .Include(p => p.Client)
                .Where(p => p.Id == query.Id)
                .Select(p => new ProjectViewModel()
                {
                    Id = p.Id.ToString(),
                    Name = p.Name,
                    ClientId = p.Client.Id.ToString()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<Project> GetByIdAsync(Guid id)
        {
            return await Entities
                .Include(p => p.Client)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}