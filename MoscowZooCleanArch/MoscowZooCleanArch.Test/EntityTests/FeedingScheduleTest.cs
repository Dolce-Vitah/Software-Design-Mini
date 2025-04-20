using Moq;
using MoscowZooCleanArch.Domain.Entities.ValueObjects;
using MoscowZooCleanArch.Domain.Entities;
using MoscowZooCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Test.EntityTests
{
    public class FeedingScheduleTest
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            var animalMock = new Mock<IAnimal>();
            animalMock.Setup(a => a.Name).Returns("Leo");
            var feedingTime = new FeedingTime(DateTime.Now.AddHours(1));
            var foodType = new Food("Meat");

            // Act
            var feedingSchedule = new FeedingSchedule(animalMock.Object, feedingTime, foodType);

            // Assert
            Assert.Equal(animalMock.Object, feedingSchedule.Animal);
            Assert.Equal(feedingTime, feedingSchedule.FeedingTime);
            Assert.Equal(foodType, feedingSchedule.FoodType);
            Assert.False(feedingSchedule.IsCompleted);
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenAnimalIsNull()
        {
            // Arrange
            var feedingTime = new FeedingTime(DateTime.Now.AddHours(1));
            var foodType = new Food("Meat");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new FeedingSchedule(null, feedingTime, foodType));
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenFeedingTimeIsNull()
        {
            // Arrange
            var animalMock = new Mock<IAnimal>();
            var foodType = new Food("Meat");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new FeedingSchedule(animalMock.Object, null, foodType));
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenFoodTypeIsNull()
        {
            // Arrange
            var animalMock = new Mock<IAnimal>();
            var feedingTime = new FeedingTime(DateTime.Now.AddHours(1));

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new FeedingSchedule(animalMock.Object, feedingTime, null));
        }

        [Fact]
        public void ChangeFeedingTime_ShouldUpdateFeedingTime()
        {
            // Arrange
            var animalMock = new Mock<IAnimal>();
            var feedingSchedule = new FeedingSchedule(animalMock.Object, new FeedingTime(DateTime.Now.AddHours(1)), new Food("Meat"));
            var newFeedingTime = new FeedingTime(DateTime.Now.AddHours(2));

            // Act
            feedingSchedule.ChangeFeedingTime(newFeedingTime);

            // Assert
            Assert.Equal(newFeedingTime, feedingSchedule.FeedingTime);
            Assert.False(feedingSchedule.IsCompleted); // Ensure IsCompleted is reset
        }

        [Fact]
        public void ChangeFeedingTime_ShouldThrowException_WhenNewFeedingTimeIsNull()
        {
            // Arrange
            var animalMock = new Mock<IAnimal>();
            var feedingSchedule = new FeedingSchedule(animalMock.Object, new FeedingTime(DateTime.Now.AddHours(1)), new Food("Meat"));

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => feedingSchedule.ChangeFeedingTime(null));
        }        

        [Fact]
        public void ChangeFoodType_ShouldUpdateFoodType()
        {
            // Arrange
            var animalMock = new Mock<IAnimal>();
            var feedingSchedule = new FeedingSchedule(animalMock.Object, new FeedingTime(DateTime.Now.AddHours(1)), new Food("Meat"));
            var newFoodType = new Food("Fish");

            // Act
            feedingSchedule.ChangeFoodType(newFoodType);

            // Assert
            Assert.Equal(newFoodType, feedingSchedule.FoodType);
        }

        [Fact]
        public void ChangeFoodType_ShouldThrowException_WhenNewFoodTypeIsNull()
        {
            // Arrange
            var animalMock = new Mock<IAnimal>();
            var feedingSchedule = new FeedingSchedule(animalMock.Object, new FeedingTime(DateTime.Now.AddHours(1)), new Food("Meat"));

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => feedingSchedule.ChangeFoodType(null));
        }

        [Fact]
        public void MarkAsCompleted_ShouldSetIsCompletedToTrue()
        {
            // Arrange
            var animalMock = new Mock<IAnimal>();
            var feedingSchedule = new FeedingSchedule(animalMock.Object, new FeedingTime(DateTime.Now.AddHours(1)), new Food("Meat"));

            // Act
            feedingSchedule.MarkAsCompleted();

            // Assert
            Assert.True(feedingSchedule.IsCompleted);
        }

        [Fact]
        public void ToString_ShouldReturnCorrectStringRepresentation()
        {
            // Arrange
            var animalMock = new Mock<IAnimal>();
            animalMock.Setup(a => a.Name).Returns("Leo");
            var feedingTime = new FeedingTime(DateTime.Now.AddHours(1));
            var foodType = new Food("Meat");
            var feedingSchedule = new FeedingSchedule(animalMock.Object, feedingTime, foodType);

            // Act
            var result = feedingSchedule.ToString();

            // Assert
            Assert.Contains("Leo", result);
            Assert.Contains("Meat", result);
            Assert.Contains(feedingTime.Time.ToString(), result);
            Assert.Contains("Completed: False", result);
        }
    }
}
