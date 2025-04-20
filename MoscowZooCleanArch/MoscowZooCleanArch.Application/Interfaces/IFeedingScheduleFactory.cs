using MoscowZooCleanArch.Application.DataTransferObjects;
using MoscowZooCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Application.Interfaces
{
    /// <summary>
    /// Interface for creating feeding schedules for animals in the zoo.
    /// </summary>
   
    public interface IFeedingScheduleFactory
    {
        IFeedingSchedule CreateFeedingSchedule(CreateFeedingScheduleDTO feedingScheduleDto, IAnimal animal);
    }
}
