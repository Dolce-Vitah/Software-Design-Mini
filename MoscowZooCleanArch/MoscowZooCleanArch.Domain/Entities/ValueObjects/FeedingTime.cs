using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Domain.Entities.ValueObjects
{
    /// <summary>
    /// Represents the feeding time of an animal in the zoo.
    /// </summary>
    
    public sealed record FeedingTime
    {
        public DateTime Time { get; }
        public FeedingTime(DateTime time)
        {            
            Time = time;
        }

        /// <summary>
        /// Implicitly converts a FeedingTime object to a DateTime representation.
        /// </summary>
        /// <param name="feedingTime"></param>

        public static implicit operator DateTime(FeedingTime feedingTime) => feedingTime.Time;

        /// <summary>
        /// Explicitly converts a DateTime to a FeedingTime object.
        /// </summary>
        /// <param name="time"></param>

        public static explicit operator FeedingTime(DateTime time) => new(time);

        public override string ToString() => Time.ToString("o");
    }
}
