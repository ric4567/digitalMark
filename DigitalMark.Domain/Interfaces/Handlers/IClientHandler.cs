using DigitalMark.DTO.Commands;
using DigitalMark.DTO.Queries;
using DigitalMark.DTO.Results;
using DigitalMark.DTO.ViewModels;

namespace DigitalMark.Domain.Interfaces.Handlers
{
    public interface IClientHandler
    {
        Task<IEnumerable<ClientViewModel>> GetClientsAsync(ClientQuery query);

        Task<SaveClientResult> SaveClientAsync(SaveClientCommand command);

        Task<UpdateClientResult> UpdateClientAsync(UpdateClientCommand command);

        Task<DeleteClientResult> DeleteClientAsync(Guid guidId);

        Task<ClientViewModel> GetByIdAsync(ClientQuery query);
    }
}