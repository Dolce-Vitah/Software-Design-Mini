using MoscowZooCleanArch.Application.DataTransferObjects;
using MoscowZooCleanArch.Application.Interfaces;
using MoscowZooCleanArch.Domain.Entities;
using MoscowZooCleanArch.Domain.Entities.ValueObjects;
using MoscowZooCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Application.Factories
{
    /// <summary>
    /// Factory class for creating feeding schedules.
    /// </summary>
    
    internal class FeedingScheduleFactory: IFeedingScheduleFactory
    {
        public IFeedingSchedule CreateFeedingSchedule(CreateFeedingScheduleDTO feedingScheduleDto, IAnimal animal)
        {
            var _feedingTime = new FeedingTime(feedingScheduleDto.FeedingTime);
            var _foodType = new Food(feedingScheduleDto.FoodType);

            return new FeedingSchedule(animal, _feedingTime, _foodType);
        }
    }    
}
