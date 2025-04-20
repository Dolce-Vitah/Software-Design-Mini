using MoscowZooCleanArch.Application.Interfaces;
using MoscowZooCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Application.Services
{
    /// <summary>
    /// Service for raising domain events.
    /// </summary>
    
    internal class DomainEventService: IDomainEventService
    {
        /// <summary>
        /// This method raises a domain event.
        /// </summary>
        /// <param name="domainEvent"></param>

        public void Raise(IDomainEvent domainEvent)
        {
            OnDomainEvent?.Invoke(domainEvent);
        }

        public event Action<IDomainEvent>? OnDomainEvent;
    }    
}
