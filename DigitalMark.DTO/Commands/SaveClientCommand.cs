using Flunt.Notifications;
using System.Diagnostics.Contracts;

namespace DigitalMark.DTO.Commands
{
    public class SaveClientCommand : Notifiable<Notification>
    {
        public string Name { get; set; }
        public string Technology { get; set; }
        public string ProjectId { get; set; }

        public virtual void Validate()
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(Name), "Nome é obrigatório");
            Contract.Requires(!string.IsNullOrWhiteSpace(Technology), "Tecnologia é obrigatória");
            Contract.Requires(Guid.TryParse(ProjectId, out _), "Projeto é obrigatório");
        }
    }
}