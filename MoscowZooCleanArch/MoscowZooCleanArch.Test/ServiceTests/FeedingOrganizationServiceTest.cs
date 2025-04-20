using Moq;
using MoscowZooCleanArch.Application.Interfaces;
using MoscowZooCleanArch.Application.Services;
using MoscowZooCleanArch.Domain.Entities.ValueObjects;
using MoscowZooCleanArch.Domain.Events;
using MoscowZooCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Test.ServiceTests
{
    public class FeedingOrganizationServiceTest
    {
        [Fact]
        public void ChangeFeedingTime_ShouldUpdateFeedingTime()
        {
            // Arrange
            var feedingScheduleId = Guid.NewGuid();
            var newFeedingTime = DateTime.Now.AddHours(1);

            var mockFeedingSchedule = new Mock<IFeedingSchedule>();
            var mockRepository = new Mock<IFeedingScheduleRepository>();
            mockRepository.Setup(repo => repo.GetById(feedingScheduleId)).Returns(mockFeedingSchedule.Object);

            var service = new FeedingOrganizationService(mockRepository.Object, Mock.Of<IDomainEventService>());

            // Act
            service.ChangeFeedingTime(feedingScheduleId, newFeedingTime);

            // Assert
            mockFeedingSchedule.Verify(fs => fs.ChangeFeedingTime(It.Is<FeedingTime>(ft => ft.Time == newFeedingTime)), Times.Once);
        }

        [Fact]
        public void ChangeFeedingTime_ShouldThrowArgumentExceptionIfScheduleNotFound()
        {
            // Arrange
            var feedingScheduleId = Guid.NewGuid();
            var newFeedingTime = DateTime.UtcNow.AddHours(1);

            var mockRepository = new Mock<IFeedingScheduleRepository>();
            mockRepository.Setup(repo => repo.GetById(feedingScheduleId)).Returns((IFeedingSchedule)null);

            var service = new FeedingOrganizationService(mockRepository.Object, Mock.Of<IDomainEventService>());

            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.ChangeFeedingTime(feedingScheduleId, newFeedingTime));
        }

        [Fact]
        public void ChangeFoodType_ShouldUpdateFoodType()
        {
            // Arrange
            var feedingScheduleId = Guid.NewGuid();
            var newFoodType = "Meat";

            var mockFeedingSchedule = new Mock<IFeedingSchedule>();
            var mockRepository = new Mock<IFeedingScheduleRepository>();
            mockRepository.Setup(repo => repo.GetById(feedingScheduleId)).Returns(mockFeedingSchedule.Object);

            var service = new FeedingOrganizationService(mockRepository.Object, Mock.Of<IDomainEventService>());

            // Act
            service.ChangeFoodType(feedingScheduleId, newFoodType);

            // Assert
            mockFeedingSchedule.Verify(fs => fs.ChangeFoodType(It.Is<Food>(f => f.Name == newFoodType)), Times.Once);
        }

        [Fact]
        public void ChangeFoodType_ShouldThrowArgumentExceptionIfScheduleNotFound()
        {
            // Arrange
            var feedingScheduleId = Guid.NewGuid();
            var newFoodType = "Meat";

            var mockRepository = new Mock<IFeedingScheduleRepository>();
            mockRepository.Setup(repo => repo.GetById(feedingScheduleId)).Returns((IFeedingSchedule)null);

            var service = new FeedingOrganizationService(mockRepository.Object, Mock.Of<IDomainEventService>());

            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.ChangeFoodType(feedingScheduleId, newFoodType));
        }

        [Fact]
        public void FeedAnimal_ShouldRaiseEventAndMarkAsCompleted()
        {
            // Arrange
            var feedingScheduleId = Guid.NewGuid();
            var feedingTime = DateTime.Now.AddMinutes(5);

            var mockFeedingSchedule = new Mock<IFeedingSchedule>();
            mockFeedingSchedule.Setup(fs => fs.FeedingTime).Returns(new FeedingTime(feedingTime));
            mockFeedingSchedule.Setup(fs => fs.IsCompleted).Returns(false);

            var mockRepository = new Mock<IFeedingScheduleRepository>();
            mockRepository.Setup(repo => repo.GetById(feedingScheduleId)).Returns(mockFeedingSchedule.Object);

            var mockDomainEventService = new Mock<IDomainEventService>();

            var service = new FeedingOrganizationService(mockRepository.Object, mockDomainEventService.Object);

            // Act
            service.FeedAnimal(feedingScheduleId);

            // Assert
            mockDomainEventService.Verify(d => d.Raise(It.IsAny<FeedingTimeEvent>()), Times.Once);
            mockFeedingSchedule.Verify(fs => fs.MarkAsCompleted(), Times.Once);
        }

        [Fact]
        public void FeedAnimal_ShouldThrowArgumentExceptionIfScheduleNotFound()
        {
            // Arrange
            var feedingScheduleId = Guid.NewGuid();

            var mockRepository = new Mock<IFeedingScheduleRepository>();
            mockRepository.Setup(repo => repo.GetById(feedingScheduleId)).Returns((IFeedingSchedule)null);

            var service = new FeedingOrganizationService(mockRepository.Object, Mock.Of<IDomainEventService>());

            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.FeedAnimal(feedingScheduleId));
        }

        [Fact]
        public void FeedAnimal_ShouldThrowInvalidOperationExceptionIfFeedingTimeNotInRange()
        {
            // Arrange
            var feedingScheduleId = Guid.NewGuid();
            var feedingTime = DateTime.Now.AddMinutes(20); // Too far in the future

            var mockFeedingSchedule = new Mock<IFeedingSchedule>();
            mockFeedingSchedule.Setup(fs => fs.FeedingTime).Returns(new FeedingTime(feedingTime));

            var mockRepository = new Mock<IFeedingScheduleRepository>();
            mockRepository.Setup(repo => repo.GetById(feedingScheduleId)).Returns(mockFeedingSchedule.Object);

            var service = new FeedingOrganizationService(mockRepository.Object, Mock.Of<IDomainEventService>());

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => service.FeedAnimal(feedingScheduleId));
        }

        [Fact]
        public void FeedAnimal_ShouldThrowInvalidOperationExceptionIfAlreadyCompleted()
        {
            // Arrange
            var feedingScheduleId = Guid.NewGuid();
            var feedingTime = DateTime.Now.AddMinutes(5);

            var mockFeedingSchedule = new Mock<IFeedingSchedule>();
            mockFeedingSchedule.Setup(fs => fs.FeedingTime).Returns(new FeedingTime(feedingTime));
            mockFeedingSchedule.Setup(fs => fs.IsCompleted).Returns(true); // Already completed

            var mockRepository = new Mock<IFeedingScheduleRepository>();
            mockRepository.Setup(repo => repo.GetById(feedingScheduleId)).Returns(mockFeedingSchedule.Object);

            var service = new FeedingOrganizationService(mockRepository.Object, Mock.Of<IDomainEventService>());

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => service.FeedAnimal(feedingScheduleId));
        }
    }
}
