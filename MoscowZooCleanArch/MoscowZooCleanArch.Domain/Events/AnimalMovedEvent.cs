using MoscowZooCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Domain.Events
{
    /// <summary>
    /// Represents an event that occurs when an animal is moved from one enclosure to another.
    /// </summary>
    /// <param name="animal"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="OccurredOn"></param>
    public sealed record AnimalMovedEvent(IAnimal animal, IEnclosure from, 
                                          IEnclosure to, DateTime OccurredOn) : IDomainEvent;
}
