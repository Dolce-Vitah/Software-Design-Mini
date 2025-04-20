using MoscowZooCleanArch.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Test.ValueObjectTests
{
    public class FeedingTimeTest
    {
        [Fact]
        public void FeedingTime_Constructor_ShouldSetTimeCorrectly()
        {
            // Arrange
            var futureTime = DateTime.Now.AddHours(1);

            // Act
            var feedingTime = new FeedingTime(futureTime);

            // Assert
            Assert.Equal(futureTime, feedingTime.Time);
        }        
    }
}
