using Flunt.Notifications;
using System.Diagnostics.Contracts;

namespace DigitalMark.DTO.Commands
{
    public class SaveProjectCommand : Notifiable<Notification>
    {
        public string Name { get; set; }

        public virtual void Validate()
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(Name), "Nome é obrigatório");
        }
    }
}