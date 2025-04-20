using Moq;
using MoscowZooCleanArch.Domain.Entities;
using MoscowZooCleanArch.Domain.Entities.ValueObjects;
using MoscowZooCleanArch.Domain.Interfaces;

namespace MoscowZooCleanArch.Test.EntityTests
{
    public class AnimalsTest
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            var name = "Leo";
            var species = new Species("Lion");
            var birthDate = new BirthDate(new DateTime(2015, 5, 20));
            var gender = Gender.Male;
            var favoriteFood = new Food("Meat");
            var healthStatus = HealthStatus.Healthy;

            // Act
            var animal = new Animal(name, species, birthDate, gender, favoriteFood, healthStatus);

            // Assert
            Assert.Equal(name, animal.Name);
            Assert.Equal(species, animal.Species);
            Assert.Equal(birthDate, animal.DateOfBirth);
            Assert.Equal(gender, animal.Gender);
            Assert.Equal(favoriteFood, animal.FavoriteFood);
            Assert.Equal(healthStatus, animal.Status);
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenNameIsNullOrEmpty()
        {
            // Arrange
            var species = new Species("Lion");
            var birthDate = new BirthDate(new DateTime(2015, 5, 20));
            var gender = Gender.Male;
            var favoriteFood = new Food("Meat");
            var healthStatus = HealthStatus.Healthy;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Animal("", species, birthDate, gender, favoriteFood, healthStatus));
            Assert.Throws<ArgumentException>(() => new Animal(null, species, birthDate, gender, favoriteFood, healthStatus));
        }

        [Fact]
        public void Feed_ShouldPrintHappyMessage_WhenFavoriteFoodIsGiven()
        {
            // Arrange
            var animal = new Animal("Leo", new Species("Lion"), new BirthDate(new DateTime(2015, 5, 20)),
                                     Gender.Male, new Food("Meat"), HealthStatus.Healthy);
            var favoriteFood = new Food("Meat");

            // Act
            using var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            animal.Feed(favoriteFood);

            // Assert
            Assert.Contains("Leo is happily eating Meat.", consoleOutput.ToString());
        }

        [Fact]
        public void Feed_ShouldPrintPreferenceMessage_WhenDifferentFoodIsGiven()
        {
            // Arrange
            var animal = new Animal("Leo", new Species("Lion"), new BirthDate(new DateTime(2015, 5, 20)),
                                     Gender.Male, new Food("Meat"), HealthStatus.Healthy);
            var differentFood = new Food("Fish");

            // Act
            using var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            animal.Feed(differentFood);

            // Assert
            Assert.Contains("Leo would prefer Meat, but is okay with Fish.", consoleOutput.ToString());
        }

        [Fact]
        public void Treat_ShouldNotChangeStatus_WhenAnimalIsHealthy()
        {
            // Arrange
            var animal = new Animal("Leo", new Species("Lion"), new BirthDate(new DateTime(2015, 5, 20)),
                                     Gender.Male, new Food("Meat"), HealthStatus.Healthy);

            // Act
            using var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            animal.Treat();

            // Assert
            Assert.Contains("Leo is healthy and doesn't need treatment.", consoleOutput.ToString());
            Assert.Equal(HealthStatus.Healthy, animal.Status);
        }

        [Fact]
        public void Treat_ShouldChangeStatusToHealthy_WhenAnimalIsUnhealthy()
        {
            // Arrange
            var animal = new Animal("Leo", new Species("Lion"), new BirthDate(new DateTime(2015, 5, 20)),
                                     Gender.Male, new Food("Meat"), HealthStatus.Unhealthy);

            // Act
            using var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            animal.Treat();

            // Assert
            Assert.Contains("Leo is receiving treatment.", consoleOutput.ToString());
            Assert.Equal(HealthStatus.Healthy, animal.Status);
        }

        [Fact]
        public void MoveToEnclosure_ShouldMoveAnimalBetweenEnclosures()
        {
            // Arrange
            var animal = new Animal("Leo", new Species("Lion"), new BirthDate(new DateTime(2015, 5, 20)),
                                     Gender.Male, new Food("Meat"), HealthStatus.Healthy);

            var fromEnclosureMock = new Mock<IEnclosure>();
            var toEnclosureMock = new Mock<IEnclosure>();

            // Act
            animal.MoveToEnclosure(fromEnclosureMock.Object, toEnclosureMock.Object);

            // Assert
            fromEnclosureMock.Verify(e => e.RemoveAnimal(animal), Times.Once);
            toEnclosureMock.Verify(e => e.AddAnimal(animal), Times.Once);
        }
    }
}