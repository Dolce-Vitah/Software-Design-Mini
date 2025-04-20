using MoscowZooCleanArch.Domain.Entities.ValueObjects;
using MoscowZooCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Domain.Events
{
    /// <summary>
    /// Represents an event that occurs when a feeding time is scheduled for an animal.
    /// </summary>
    /// <param name="feedingSchedule"></param>
    /// <param name="OccurredOn"></param>
    public sealed record FeedingTimeEvent(IFeedingSchedule feedingSchedule, DateTime OccurredOn): IDomainEvent;
}
