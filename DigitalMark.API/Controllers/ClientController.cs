using DigitalMark.Domain.Interfaces.Handlers;
using DigitalMark.DTO.Commands;
using DigitalMark.DTO.Queries;
using DigitalMark.DTO.Results;
using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMark.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientHandler _clientHandler;

        public ClientController(IClientHandler clientHandler)
        {
            _clientHandler = clientHandler;
        }

        [HttpPost]
        public async Task<IActionResult> SaveClient([FromBody] SaveClientCommand command)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return BadRequest(new SaveClientResult(command.Notifications));
            }

            return Ok(await _clientHandler.SaveClientAsync(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient([FromRoute] string id, [FromBody] UpdateClientCommand command)
        {
            if (!Guid.TryParse(id, out Guid guidId))
            {
                return BadRequest(new DeleteClientResult(new List<Notification>() { new Notification("Id", "Id inválido") }));
            }

            command.SetId(guidId);

            command.Validate();
            if (!command.IsValid)
            {
                return BadRequest(new UpdateClientResult(command.Notifications));
            }

            return Ok(await _clientHandler.UpdateClientAsync(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(string id)
        {
            if (!Guid.TryParse(id, out Guid guidId))
            {
                return BadRequest(new DeleteClientResult(new List<Notification>() { new Notification("Id", "Id inválido") }));
            }
            return Ok(await _clientHandler.DeleteClientAsync(guidId));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ClientQuery query)
        {
            return Ok(await _clientHandler.GetClientsAsync(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            if (!Guid.TryParse(id, out Guid guidId))
            {
                return BadRequest(new DeleteClientResult(new List<Notification>() { new Notification("Id", "Id inválido") }));
            }

            var query = new ClientQuery()
            {
                Id = guidId
            };

            return Ok(await _clientHandler.GetByIdAsync(query));
        }
    }
}