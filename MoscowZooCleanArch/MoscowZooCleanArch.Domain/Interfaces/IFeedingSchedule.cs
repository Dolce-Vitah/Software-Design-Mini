using MoscowZooCleanArch.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Domain.Interfaces
{
    /// <summary>
    /// Represents a feeding schedule for an animal in the zoo.
    /// </summary>
    public interface IFeedingSchedule
    {
        Guid ID { get; }

        IAnimal Animal { get; }

        FeedingTime FeedingTime { get; }

        Food FoodType { get; }

        bool IsCompleted { get; }

        void ChangeFeedingTime(FeedingTime newFeedingTime);

        void ChangeFoodType(Food type);

        void MarkAsCompleted();
    }
}
