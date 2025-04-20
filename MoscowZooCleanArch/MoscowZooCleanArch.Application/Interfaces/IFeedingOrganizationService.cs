using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Application.Interfaces
{
    /// <summary>
    /// Interface for managing feeding schedules and operations in the zoo.
    /// </summary>
    public interface IFeedingOrganizationService
    {
        void ChangeFeedingTime(Guid scheduleId, DateTime newTime);

        void ChangeFoodType(Guid scheduleId, string newFoodType);

        void FeedAnimal(Guid feedingScheduleId);
    }
}
