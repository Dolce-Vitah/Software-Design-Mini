using Moq;
using MoscowZooCleanArch.Application.DataTransferObjects;
using MoscowZooCleanArch.Application.Factories;
using MoscowZooCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Test.FactoryTests
{
    public class FeedingScheduleFactoryTest
    {
        [Fact]
        public void CreateFeedingSchedule_ShouldReturnFeedingScheduleWithCorrectProperties()
        {
            // Arrange
            var feedingScheduleDto = new CreateFeedingScheduleDTO
            {
                FeedingTime = DateTime.Now.AddHours(1),
                FoodType = "Meat"
            };

            var mockAnimal = new Mock<IAnimal>();
            mockAnimal.Setup(a => a.Name).Returns("Leo");

            var factory = new FeedingScheduleFactory();

            // Act
            var feedingSchedule = factory.CreateFeedingSchedule(feedingScheduleDto, mockAnimal.Object);

            // Assert
            Assert.NotNull(feedingSchedule);
            Assert.Equal(feedingScheduleDto.FeedingTime, feedingSchedule.FeedingTime.Time);
            Assert.Equal(feedingScheduleDto.FoodType, feedingSchedule.FoodType.Name);
            Assert.Equal(mockAnimal.Object, feedingSchedule.Animal);
            Assert.False(feedingSchedule.IsCompleted);
        }        

        [Fact]
        public void CreateFeedingSchedule_ShouldThrowArgumentExceptionForEmptyFoodType()
        {
            // Arrange
            var feedingScheduleDto = new CreateFeedingScheduleDTO
            {
                FeedingTime = DateTime.Now.AddHours(1),
                FoodType = "" // Empty food type
            };

            var mockAnimal = new Mock<IAnimal>();
            var factory = new FeedingScheduleFactory();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateFeedingSchedule(feedingScheduleDto, mockAnimal.Object));
        }

        [Fact]
        public void CreateFeedingSchedule_ShouldThrowArgumentNullExceptionForNullAnimal()
        {
            // Arrange
            var feedingScheduleDto = new CreateFeedingScheduleDTO
            {
                FeedingTime = DateTime.Now.AddHours(1),
                FoodType = "Meat"
            };

            var factory = new FeedingScheduleFactory();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => factory.CreateFeedingSchedule(feedingScheduleDto, null));
        }
    }
}
