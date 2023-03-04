using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMark.Domain.Entities
{
    public class Client
    {
        private List<Project> _projects;

        public Client(string name)
        {
            Name = name;
            _projects = new List<Project>();
        }

        private Client()
        {
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public IReadOnlyCollection<Project> Projects => _projects;

        public void AddProject(Project project)
        {
            _projects.Add(project);
        }
    }
}
