using MoscowZooCleanArch.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Application.Services
{
    /// <summary>
    /// Provides information about feeding schedules in the zoo.
    /// </summary>
    
    internal class FeedingScheduleInformationService : IFeedingScheduleInformationService
    {
        private readonly IFeedingScheduleRepository _feedingScheduleRepository;

        public FeedingScheduleInformationService(IFeedingScheduleRepository feedingScheduleRepository)
        {
            _feedingScheduleRepository = feedingScheduleRepository;
        }

        /// <summary>
        /// Displays all feeding schedules for animals in the zoo.
        /// </summary>

        public void ViewAllFeedingSchedules()
        {
            var feedingSchedules = _feedingScheduleRepository.GetAllSchedules();
            if (feedingSchedules != null)
            {
                Console.WriteLine("Feeding schedule for animals: \n");
                foreach (var feedingSchedule in feedingSchedules)
                {
                    Console.WriteLine($"- {feedingSchedule}");
                }
            }

        }

        /// <summary>
        /// Displays the feeding schedule for a specific animal.
        /// </summary>
        /// <param name="feedingScheduleId"></param>

        public void ViewFeedingScheduleById(Guid feedingScheduleId)
        {
            var feedingSchedule = _feedingScheduleRepository.GetById(feedingScheduleId);
            if (feedingSchedule != null)
            {
                Console.WriteLine(feedingSchedule);
            }
        }        
    }
}
