using MoscowZooCleanArch.Application.Interfaces;
using MoscowZooCleanArch.Domain.Entities.ValueObjects;
using MoscowZooCleanArch.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Application.Services
{
    /// <summary>
    /// Service for managing feeding schedules and feeding animals.
    /// </summary>
    
    internal class FeedingOrganizationService: IFeedingOrganizationService
    {
        private readonly IFeedingScheduleRepository _feedingOrganizationRepository;
        private readonly IDomainEventService _domainEventService;

        public FeedingOrganizationService(IFeedingScheduleRepository feedingOrganizationRepository, IDomainEventService domainEventService)
        {
            _feedingOrganizationRepository = feedingOrganizationRepository;
            _domainEventService = domainEventService;
        }        

        /// <summary>
        /// Changes the feeding time for a specific feeding schedule.
        /// </summary>
        /// <param name="feedingScheduleId"></param>
        /// <param name="newFeedingTime"></param>
        /// <exception cref="ArgumentException"></exception>

        public void ChangeFeedingTime(Guid feedingScheduleId, DateTime newFeedingTime)
        {
            var feedingSchedule = _feedingOrganizationRepository.GetById(feedingScheduleId);
            if (feedingSchedule == null)
            {
                throw new ArgumentException($"Feeding schedule with ID {feedingScheduleId} not found.");
            }

            var newFeedingTimeObject = new FeedingTime(newFeedingTime);

            feedingSchedule.ChangeFeedingTime(newFeedingTimeObject);
        }

        /// <summary>
        /// Changes the food type for a specific feeding schedule.
        /// </summary>
        /// <param name="feedingScheduleId"></param>
        /// <param name="newFoodType"></param>
        /// <exception cref="ArgumentException"></exception>

        public void ChangeFoodType(Guid feedingScheduleId, string newFoodType)
        {
            var feedingSchedule = _feedingOrganizationRepository.GetById(feedingScheduleId);
            if (feedingSchedule == null)
            {
                throw new ArgumentException($"Feeding schedule with ID {feedingScheduleId} not found.");
            }
            var foodTypeObject = new Food(newFoodType);
            feedingSchedule.ChangeFoodType(foodTypeObject);
        }

        /// <summary>
        /// Feeds the animal according to the feeding schedule.
        /// An animal can be fed 10 minutes before the scheduled time.
        /// </summary>
        /// <param name="feedingScheduleId"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>

        public void FeedAnimal(Guid feedingScheduleId)
        {
            var feedingSchedule = _feedingOrganizationRepository.GetById(feedingScheduleId);
            if (feedingSchedule == null)
            {
                throw new ArgumentException($"Feeding schedule with ID {feedingScheduleId} not found.");
            }
            if ((feedingSchedule.FeedingTime.Time - DateTime.Now).TotalMinutes > 10)
            {
                throw new InvalidOperationException("Feeding time is not within the allowed range.");
            }
            if (feedingSchedule.IsCompleted)
            {
                throw new InvalidOperationException("Feeding schedule is already completed.");
            }

            _domainEventService.Raise(new FeedingTimeEvent(feedingSchedule, DateTime.Now));
            feedingSchedule.MarkAsCompleted();
        }
    }
}
