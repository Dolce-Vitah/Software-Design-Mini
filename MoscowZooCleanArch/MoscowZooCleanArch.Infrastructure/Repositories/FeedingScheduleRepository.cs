using MoscowZooCleanArch.Application.Interfaces;
using MoscowZooCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Infrastructure.Repositories
{
    /// <summary>
    /// This class provides methods to manage feeding schedules in the zoo.
    /// </summary>
    public class FeedingScheduleRepository: IFeedingScheduleRepository
    {
        private List<IFeedingSchedule> _feedingSchedules = new List<IFeedingSchedule>();

        public void AddFeedingSchedule(IFeedingSchedule feedingSchedule)
        {
            if (feedingSchedule == null)
            {
                throw new ArgumentNullException("Feeding schedule cannot be null", nameof(feedingSchedule));
            }
            if (!_feedingSchedules.Contains(feedingSchedule))
            {
                _feedingSchedules.Add(feedingSchedule);
            }
        }

        public void DeleteFeedingSchedule(IFeedingSchedule feedingSchedule)
        {
            if (feedingSchedule == null)
            {
                throw new ArgumentNullException("Feeding schedule cannot be null", nameof(feedingSchedule));
            }
            if (_feedingSchedules.Contains(feedingSchedule))
            {
                _feedingSchedules.Remove(feedingSchedule);
            }
        }

        public IFeedingSchedule? GetById(Guid id)
        {
            return _feedingSchedules.FirstOrDefault(fs => fs.ID == id);
        }

        public IReadOnlyList<IFeedingSchedule> GetAllSchedules()
        {
            return _feedingSchedules.AsReadOnly();
        }
    }    
}
