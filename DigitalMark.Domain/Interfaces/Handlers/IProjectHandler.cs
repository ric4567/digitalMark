using DigitalMark.DTO.Commands;
using DigitalMark.DTO.Queries;
using DigitalMark.DTO.Results;
using DigitalMark.DTO.ViewModels;

namespace DigitalMark.Domain.Interfaces.Handlers
{
    public interface IProjectHandler
    {
        Task<IEnumerable<ProjectViewModel>> GetProjectsAsync(ProjectQuery query);

        Task<ProjectViewModel> GetByIdAsync(ProjectQuery query);

        Task<SaveProjectResult> SaveProjectAsync(SaveProjectCommand command);

        Task<UpdateProjectResult> UpdateProjectAsync(UpdateProjectCommand command);

        Task<DeleteProjectResult> DeleteProjectAsync(Guid guidId);
    }
}