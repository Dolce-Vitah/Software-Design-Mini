using MoscowZooCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Application.Interfaces
{
    /// <summary>
    /// Interface for the Feeding Schedule Statistics Service.
    /// </summary>
    public interface IFeedingScheduleStatisticsService
    {
        IReadOnlyList<IFeedingSchedule> GetUpcomingFeedingSchedules();

        IReadOnlyList<IFeedingSchedule> GetMissedFeedingSchedules();
    }
}
