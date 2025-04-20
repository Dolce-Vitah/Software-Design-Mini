using Moq;
using MoscowZooCleanArch.Application.Interfaces;
using MoscowZooCleanArch.Application.Services;
using MoscowZooCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Test.ServiceTests
{
    public class FeedingScheduleInformationServiceTest
    {
        [Fact]
        public void ViewAllFeedingSchedules_ShouldDisplayAllSchedules()
        {
            // Arrange
            var mockFeedingSchedule1 = Mock.Of<IFeedingSchedule>(fs => fs.ToString() == "Feeding Schedule 1");
            var mockFeedingSchedule2 = Mock.Of<IFeedingSchedule>(fs => fs.ToString() == "Feeding Schedule 2");

            var mockRepository = new Mock<IFeedingScheduleRepository>();
            mockRepository.Setup(repo => repo.GetAllSchedules()).Returns(new List<IFeedingSchedule>
            {
                mockFeedingSchedule1,
                mockFeedingSchedule2
            });

            var service = new FeedingScheduleInformationService(mockRepository.Object);

            using (var consoleOutput = new ConsoleOutput())
            {
                // Act
                service.ViewAllFeedingSchedules();

                // Assert
                var output = consoleOutput.GetOutput();
                Assert.Contains("Feeding Schedule 1", output);
                Assert.Contains("Feeding Schedule 2", output);
            }
        }

        [Fact]
        public void ViewAllFeedingSchedules_ShouldHandleNoSchedulesGracefully()
        {
            // Arrange
            var mockRepository = new Mock<IFeedingScheduleRepository>();
            mockRepository.Setup(repo => repo.GetAllSchedules()).Returns(new List<IFeedingSchedule>());

            var service = new FeedingScheduleInformationService(mockRepository.Object);

            using (var consoleOutput = new ConsoleOutput())
            {
                // Act
                service.ViewAllFeedingSchedules();

                // Assert
                var output = consoleOutput.GetOutput();
                Assert.DoesNotContain("Feeding Schedule", output); // No schedules should be displayed
            }
        }

        [Fact]
        public void ViewFeedingScheduleById_ShouldDisplaySpecificSchedule()
        {
            // Arrange
            var feedingScheduleId = Guid.NewGuid();
            var mockFeedingSchedule = Mock.Of<IFeedingSchedule>(fs => fs.ToString() == "Specific Feeding Schedule");

            var mockRepository = new Mock<IFeedingScheduleRepository>();
            mockRepository.Setup(repo => repo.GetById(feedingScheduleId)).Returns(mockFeedingSchedule);

            var service = new FeedingScheduleInformationService(mockRepository.Object);

            using (var consoleOutput = new ConsoleOutput())
            {
                // Act
                service.ViewFeedingScheduleById(feedingScheduleId);

                // Assert
                var output = consoleOutput.GetOutput();
                Assert.Contains("Specific Feeding Schedule", output);
            }
        }

        [Fact]
        public void ViewFeedingScheduleById_ShouldHandleScheduleNotFoundGracefully()
        {
            // Arrange
            var feedingScheduleId = Guid.NewGuid();

            var mockRepository = new Mock<IFeedingScheduleRepository>();
            mockRepository.Setup(repo => repo.GetById(feedingScheduleId)).Returns((IFeedingSchedule)null);

            var service = new FeedingScheduleInformationService(mockRepository.Object);

            using (var consoleOutput = new ConsoleOutput())
            {
                // Act
                service.ViewFeedingScheduleById(feedingScheduleId);

                // Assert
                var output = consoleOutput.GetOutput();
                Assert.DoesNotContain("Feeding Schedule", output); // No schedule should be displayed
            }
        }        
    }

    /// <summary>
    /// Helper class to capture console output during tests.
    /// </summary>
    public class ConsoleOutput : IDisposable
    {
        private readonly System.IO.StringWriter _stringWriter;
        private readonly System.IO.TextWriter _originalOutput;

        public ConsoleOutput()
        {
            _stringWriter = new System.IO.StringWriter();
            _originalOutput = Console.Out;
            Console.SetOut(_stringWriter);
        }

        public string GetOutput()
        {
            return _stringWriter.ToString();
        }

        public void Dispose()
        {
            Console.SetOut(_originalOutput);
            _stringWriter.Dispose();
        }
    }
}
