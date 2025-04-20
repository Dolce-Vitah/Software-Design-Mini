using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Application.DataTransferObjects
{
    /// <summary>
    /// Data Transfer Object for creating a feeding schedule.
    /// </summary>
    public class CreateFeedingScheduleDTO
    {
        public DateTime FeedingTime { get; set; }

        public string FoodType { get; set; }
    }
}
