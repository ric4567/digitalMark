using Flunt.Notifications;
using System.Diagnostics.Contracts;

namespace DigitalMark.Domain.Entities
{
    public class Client : Notifiable<Notification>
    {
        public Client(string name, string tecnology, Project project)
        {
            Name = name;
            Technology = tecnology;
            Project = project;

            Validate();
        }

        private Client()
        {
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Technology { get; private set; }
        public Guid ProjectId { get; private set; }
        public Project Project { get; private set; }

        public void Update(string name, string tecnology, Project project)
        {
            Name = name;
            Technology = tecnology;
            Project = project;

            Validate();
        }

        public void Validate()
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(Name), "Nome é obrigatório");
            Contract.Requires(!string.IsNullOrWhiteSpace(Technology), "Tecnologia é obrigatória");
            Contract.Requires(Project != null, "Projeto é obrigatório");
        }
    }
}