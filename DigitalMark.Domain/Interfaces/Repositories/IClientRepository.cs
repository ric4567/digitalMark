using DigitalMark.Domain.Entities;
using DigitalMark.DTO.Queries;
using DigitalMark.DTO.ViewModels;

namespace DigitalMark.Domain.Interfaces.Repositories
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        Task<IEnumerable<ClientViewModel>> GetAsync(ClientQuery query);
        Task<Client> GetByIdAsync(Guid id);
        Task<ClientViewModel> GetViewModelByAsync(ClientQuery query);
    }
}