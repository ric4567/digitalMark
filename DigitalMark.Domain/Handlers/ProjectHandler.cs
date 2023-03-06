using DigitalMark.Domain.Entities;
using DigitalMark.Domain.Interfaces;
using DigitalMark.Domain.Interfaces.Handlers;
using DigitalMark.Domain.Interfaces.Repositories;
using DigitalMark.DTO.Commands;
using DigitalMark.DTO.Queries;
using DigitalMark.DTO.Results;
using DigitalMark.DTO.ViewModels;
using Flunt.Notifications;

namespace DigitalMark.Domain.Handlers
{
    public class ProjectHandler : IProjectHandler
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProjectHandler(IProjectRepository projectRepository,
                              IClientRepository clientRepository,
                              IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<SaveProjectResult> SaveProjectAsync(SaveProjectCommand command)
        {
            var project = new Project(command.Name);

            if (project.IsValid)
            {
                try
                {
                    await _projectRepository.AddAsync(project);
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (Exception x)
                {
                    project.AddNotification(new Notification(x.Message, x.StackTrace));
                }
            }

            return new SaveProjectResult(project.Notifications);
        }

        public async Task<UpdateProjectResult> UpdateProjectAsync(UpdateProjectCommand command)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new UpdateProjectResult(command.Notifications);
            }

            Project project = await _projectRepository.GetByIdAsync(command.Id);
            if (project == null)
            {
                command.AddNotification(new Notification("Projeto", "Projeto não encontrado"));
                return new UpdateProjectResult(command.Notifications);
            }

            project.Update(command.Name);

            if (project.IsValid)
            {
                try
                {
                    _projectRepository.Update(project);
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (Exception x)
                {
                    project.AddNotification(new Notification(x.Message, x.StackTrace));
                }
            }

            return new UpdateProjectResult(project.Notifications);
        }

        public async Task<DeleteProjectResult> DeleteProjectAsync(Guid id)
        {
            Project project = await _projectRepository.GetByIdAsync(id);
            if (project == null)
            {
                return new DeleteProjectResult(new List<Notification>() { new Notification("Projeto", "Projeto não encontrado") });
            }

            try
            {
                _projectRepository.Remove(project);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception x)
            {
                project.AddNotification(new Notification(x.Message, x.StackTrace));
            }

            return new DeleteProjectResult(project.Notifications);
        }

        public async Task<IEnumerable<ProjectViewModel>> GetProjectsAsync(ProjectQuery query)
        {
            return await _projectRepository.GetAsync(query);
        }

        public async Task<ProjectViewModel> GetByIdAsync(ProjectQuery query)
        {
            return await _projectRepository.GetViewModelByAsync(query);
        }
    }
}