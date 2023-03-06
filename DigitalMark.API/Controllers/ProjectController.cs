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
    public class ProjectController : ControllerBase
    {
        private readonly IProjectHandler _projectHandler;

        public ProjectController(IProjectHandler projectHandler)
        {
            _projectHandler = projectHandler;
        }

        [HttpPost]
        public async Task<IActionResult> SaveProject([FromBody] SaveProjectCommand command)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return BadRequest(new SaveProjectResult(command.Notifications));
            }

            return Ok(await _projectHandler.SaveProjectAsync(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject([FromRoute] string id, [FromBody] UpdateProjectCommand command)
        {
            if (!Guid.TryParse(id, out Guid guidId))
            {
                return BadRequest(new DeleteClientResult(new List<Notification>() { new Notification("Id", "Id inválido") }));
            }

            command.SetId(guidId);

            command.Validate();
            if (!command.IsValid)
            {
                return BadRequest(new UpdateProjectResult(command.Notifications));
            }

            return Ok(await _projectHandler.UpdateProjectAsync(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(string id)
        {
            if (!Guid.TryParse(id, out Guid guidId))
            {
                return BadRequest(new DeleteProjectResult(new List<Notification>() { new Notification("Id", "Id inválido") }));
            }
            return Ok(await _projectHandler.DeleteProjectAsync(guidId));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ProjectQuery query)
        {
            return Ok(await _projectHandler.GetProjectsAsync(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            if (!Guid.TryParse(id, out Guid guidId))
            {
                return BadRequest(new DeleteProjectResult(new List<Notification>() { new Notification("Id", "Id inválido") }));
            }

            var query = new ProjectQuery()
            {
                Id = guidId
            };

            return Ok(await _projectHandler.GetByIdAsync(query));
        }
    }
}