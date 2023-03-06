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
    public class ClientHandler : IClientHandler
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ClientHandler(IProjectRepository projectRepository,
                             IClientRepository clientRepository,
                             IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<SaveClientResult> SaveClientAsync(SaveClientCommand command)
        {
            Project project = await _projectRepository.GetByIdAsync(Guid.Parse(command.ProjectId));

            var client = new Client(command.Name, command.Technology, project);

            if (client.IsValid)
            {
                try
                {
                    await _clientRepository.AddAsync(client);
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (Exception x)
                {
                    client.AddNotification(new Notification(x.Message, x.StackTrace));
                }
            }

            return new SaveClientResult(client.Notifications);
        }

        public async Task<UpdateClientResult> UpdateClientAsync(UpdateClientCommand command)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new UpdateClientResult(command.Notifications);
            }

            Client client = await _clientRepository.GetByIdAsync(command.Id);
            if (client == null)
            {
                command.AddNotification(new Notification("Cliente", "Cliente não encontrado"));
                return new UpdateClientResult(command.Notifications);
            }
            Project project = client.Project;
            if (client.ProjectId.ToString() != command.ProjectId)
            {
                project = await _projectRepository.GetByIdAsync(Guid.Parse(command.ProjectId));
            }

            client.Update(command.Name, command.Technology, project);

            if (client.IsValid)
            {
                try
                {
                    _clientRepository.Update(client);
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (Exception x)
                {
                    client.AddNotification(new Notification(x.Message, x.StackTrace));
                }
            }

            return new UpdateClientResult(client.Notifications);
        }

        public async Task<DeleteClientResult> DeleteClientAsync(Guid id)
        {
            Client client = await _clientRepository.GetByIdAsync(id);
            if (client == null)
            {
                return new DeleteClientResult(new List<Notification>() { new Notification("Projeto", "Projeto não encontrado") });
            }

            try
            {
                _clientRepository.RemoveAsync(client);
            }
            catch (Exception x)
            {
                client.AddNotification(new Notification(x.Message, x.StackTrace));
            }

            return new DeleteClientResult(client.Notifications);
        }

        public async Task<IEnumerable<ClientViewModel>> GetClientsAsync(ClientQuery query)
        {
            return await _clientRepository.GetAsync(query);
        }

        public async Task<ClientViewModel> GetByIdAsync(ClientQuery query)
        {
            return await _clientRepository.GetViewModelByAsync(query);
        }
    }
}