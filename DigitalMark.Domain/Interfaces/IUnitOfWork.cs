using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMark.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public Task SaveChangesAsync();
    }
}
