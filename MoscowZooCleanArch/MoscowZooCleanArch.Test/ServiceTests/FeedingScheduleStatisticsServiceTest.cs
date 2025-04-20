using Moq;
using MoscowZooCleanArch.Application.Interfaces;
using MoscowZooCleanArch.Application.Services;
using MoscowZooCleanArch.Domain.Entities.ValueObjects;
using MoscowZooCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Test.ServiceTests
{
    public class FeedingScheduleStatisticsServiceTest
    {
        [Fact]
        public void GetUpcomingFeedingSchedules_ShouldReturnSchedulesWithFutureFeedingTimes()
        {
            // Arrange
            var mockFeedingSchedule1 = new Mock<IFeedingSchedule>();
            mockFeedingSchedule1.Setup(fs => fs.FeedingTime).Returns(new FeedingTime(DateTime.Now.AddHours(1)));

            var mockFeedingSchedule2 = new Mock<IFeedingSchedule>();
            mockFeedingSchedule2.Setup(fs => fs.FeedingTime).Returns(new FeedingTime(DateTime.Now.AddHours(2)));

            var mockFeedingSchedule3 = new Mock<IFeedingSchedule>();
            mockFeedingSchedule3.Setup(fs => fs.FeedingTime).Returns(new FeedingTime(DateTime.Now.AddHours(-1))); // Past time
                                                                                                                     

            var mockRepository = new Mock<IFeedingScheduleRepository>();
            mockRepository.Setup(repo => repo.GetAllSchedules()).Returns(new List<IFeedingSchedule>
            {
                mockFeedingSchedule1.Object,
                mockFeedingSchedule2.Object,
                mockFeedingSchedule3.Object
            });

            var service = new FeedingScheduleStatisticsService(mockRepository.Object);

            // Act
            var upcomingSchedules = service.GetUpcomingFeedingSchedules();

            // Assert
            Assert.Equal(2, upcomingSchedules.Count);
            Assert.Contains(mockFeedingSchedule1.Object, upcomingSchedules);
            Assert.Contains(mockFeedingSchedule2.Object, upcomingSchedules);
        }

        [Fact]
        public void GetMissedFeedingSchedules_ShouldReturnSchedulesWithPastFeedingTimes()
        {
            // Arrange
            var mockFeedingSchedule1 = new Mock<IFeedingSchedule>();
            mockFeedingSchedule1.Setup(fs => fs.FeedingTime).Returns(new FeedingTime(DateTime.Now.AddHours(-1)));

            var mockFeedingSchedule2 = new Mock<IFeedingSchedule>();
            mockFeedingSchedule2.Setup(fs => fs.FeedingTime).Returns(new FeedingTime(DateTime.Now.AddHours(-2)));

            var mockFeedingSchedule3 = new Mock<IFeedingSchedule>();
            mockFeedingSchedule3.Setup(fs => fs.FeedingTime).Returns(new FeedingTime(DateTime.Now.AddHours(1))); // Future time

            var mockRepository = new Mock<IFeedingScheduleRepository>();
            mockRepository.Setup(repo => repo.GetAllSchedules()).Returns(new List<IFeedingSchedule>
            {
                mockFeedingSchedule1.Object,
                mockFeedingSchedule2.Object,
                mockFeedingSchedule3.Object
            });

            var service = new FeedingScheduleStatisticsService(mockRepository.Object);

            // Act
            var missedSchedules = service.GetMissedFeedingSchedules();

            // Assert
            Assert.Equal(2, missedSchedules.Count);
            Assert.Contains(mockFeedingSchedule1.Object, missedSchedules);
            Assert.Contains(mockFeedingSchedule2.Object, missedSchedules);
        }

        [Fact]
        public void GetUpcomingFeedingSchedules_ShouldReturnEmptyListIfNoFutureSchedules()
        {
            // Arrange
            var mockFeedingSchedule1 = new Mock<IFeedingSchedule>();
            mockFeedingSchedule1.Setup(fs => fs.FeedingTime).Returns(new FeedingTime(DateTime.Now.AddHours(-1)));

            var mockFeedingSchedule2 = new Mock<IFeedingSchedule>();
            mockFeedingSchedule2.Setup(fs => fs.FeedingTime).Returns(new FeedingTime(DateTime.Now.AddHours(-2)));

            var mockRepository = new Mock<IFeedingScheduleRepository>();
            mockRepository.Setup(repo => repo.GetAllSchedules()).Returns(new List<IFeedingSchedule>
            {
                mockFeedingSchedule1.Object,
                mockFeedingSchedule2.Object
            });

            var service = new FeedingScheduleStatisticsService(mockRepository.Object);

            // Act
            var upcomingSchedules = service.GetUpcomingFeedingSchedules();

            // Assert
            Assert.Empty(upcomingSchedules);
        }

        [Fact]
        public void GetMissedFeedingSchedules_ShouldReturnEmptyListIfNoPastSchedules()
        {
            // Arrange
            var mockFeedingSchedule1 = new Mock<IFeedingSchedule>();
            mockFeedingSchedule1.Setup(fs => fs.FeedingTime).Returns(new FeedingTime(DateTime.Now.AddHours(1)));

            var mockFeedingSchedule2 = new Mock<IFeedingSchedule>();
            mockFeedingSchedule2.Setup(fs => fs.FeedingTime).Returns(new FeedingTime(DateTime.Now.AddHours(2)));

            var mockRepository = new Mock<IFeedingScheduleRepository>();
            mockRepository.Setup(repo => repo.GetAllSchedules()).Returns(new List<IFeedingSchedule>
            {
                mockFeedingSchedule1.Object,
                mockFeedingSchedule2.Object
            });

            var service = new FeedingScheduleStatisticsService(mockRepository.Object);

            // Act
            var missedSchedules = service.GetMissedFeedingSchedules();

            // Assert
            Assert.Empty(missedSchedules);
        }
    }
}
