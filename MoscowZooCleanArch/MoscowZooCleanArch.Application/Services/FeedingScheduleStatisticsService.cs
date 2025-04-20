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
    /// This service is responsible for retrieving statistics about feeding schedules in the zoo.
    /// </summary>

    internal class FeedingScheduleStatisticsService: IFeedingScheduleStatisticsService
    {
        private readonly IFeedingScheduleRepository _feedingScheduleRepository;

        public FeedingScheduleStatisticsService(IFeedingScheduleRepository feedingScheduleRepository)
        {
            _feedingScheduleRepository = feedingScheduleRepository;
        }

        /// <summary>
        /// Returns a list of upcoming feeding schedules.
        /// </summary>
        /// <returns></returns>

        public IReadOnlyList<IFeedingSchedule> GetUpcomingFeedingSchedules()
        {
            return _feedingScheduleRepository.GetAllSchedules()
                .Where(fs => fs.FeedingTime >= DateTime.Now)
                .ToList();
        }

        /// <summary>
        /// Returns a list of missed feeding schedules.
        /// </summary>
        /// <returns></returns>

        public IReadOnlyList<IFeedingSchedule> GetMissedFeedingSchedules()
        {
            return _feedingScheduleRepository.GetAllSchedules()
                .Where(fs => fs.FeedingTime < DateTime.Now)
                .ToList();
        }
    }
}
