using Flunt.Notifications;
using System.Diagnostics.Contracts;

namespace DigitalMark.Domain.Entities
{
    public class Project : Notifiable<Notification>
    {
        public Project(string name)
        {
            Name = name;

            Validate();
        }

        private Project()
        {
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Client Client { get; private set; }

        public virtual void Validate()
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(Name), "Nome é obrigatório");
        }

        internal void Update(string name)
        {
            Name = name ?? Name;
        }
    }
}