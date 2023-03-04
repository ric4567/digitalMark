using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMark.Domain.Entities
{
    public class Project
    {
        public Project(string name)
        {
            Name = name;
        }

        private Project()
        {
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Client Client { get; private set; }
    }
}
