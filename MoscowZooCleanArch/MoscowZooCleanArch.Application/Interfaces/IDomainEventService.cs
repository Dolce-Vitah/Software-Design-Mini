using MoscowZooCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Application.Interfaces
{
    /// <summary>
    /// Represents a service for raising domain events.
    /// </summary>
    
    public interface IDomainEventService
    {
        void Raise(IDomainEvent domainEvent);

        event Action<IDomainEvent> OnDomainEvent;
    }
}
