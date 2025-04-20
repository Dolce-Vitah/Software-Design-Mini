using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Domain.Interfaces
{
    /// <summary>
    /// Represents a domain event in the system.
    /// </summary>
    
    public interface IDomainEvent
    {
        public DateTime OccurredOn { get; }
    }
}
