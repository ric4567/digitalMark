using DigitalMark.Domain.Entities;
using DigitalMark.DTO.Queries;
using DigitalMark.DTO.ViewModels;

namespace DigitalMark.Domain.Interfaces.Repositories
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        Task<ProjectViewModel> GetViewModelByAsync(ProjectQuery query);

        Task<IEnumerable<ProjectViewModel>> GetAsync(ProjectQuery query);

        Task<Project> GetByIdAsync(Guid id);
    }
}