using System.Diagnostics.Contracts;

namespace DigitalMark.DTO.Commands
{
    public class UpdateProjectCommand : SaveProjectCommand
    {
        public Guid Id { get; private set; }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}