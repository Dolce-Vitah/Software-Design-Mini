using MoscowZooCleanArch.Domain.Entities;
using MoscowZooCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Application.Interfaces
{
    /// <summary>
    /// Interface for the Feeding Schedule Repository.
    /// </summary>
    
    public interface IFeedingScheduleRepository
    {
        void AddFeedingSchedule(IFeedingSchedule schedule);

        void DeleteFeedingSchedule(IFeedingSchedule schedule);

        IFeedingSchedule? GetById(Guid id);

        IReadOnlyList<IFeedingSchedule> GetAllSchedules();
    }
}
