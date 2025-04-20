using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Application.Interfaces
{
    /// <summary>
    /// Interface for the Feeding Schedule Information Service.
    /// </summary>
   
    public interface IFeedingScheduleInformationService
    {
        void ViewAllFeedingSchedules();

        void ViewFeedingScheduleById(Guid feedingScheduleId);
    }
}
