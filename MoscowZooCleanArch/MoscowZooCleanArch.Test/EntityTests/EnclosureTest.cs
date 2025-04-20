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
    public class EnclosureTest
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            var type = EnclosureType.Predator;
            var size = new EnclosureSize(20, 10, 30);
            var maxCapacity = 5;

            // Act
            var enclosure = new Enclosure(type, size, maxCapacity);

            // Assert
            Assert.Equal(type, enclosure.Type);
            Assert.Equal(size, enclosure.Size);
            Assert.Equal(maxCapacity, enclosure.MaxCapacity);
            Assert.Equal(0, enclosure.CurrentOccupancy);
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenTypeIsNull()
        {
            // Arrange
            var size = new EnclosureSize(20, 10, 30);
            var maxCapacity = 5;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Enclosure(null, size, maxCapacity));
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenSizeIsNull()
        {
            // Arrange
            var type = EnclosureType.Predator;
            var maxCapacity = 5;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Enclosure(type, null, maxCapacity));
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenMaxCapacityIsInvalid()
        {
            // Arrange
            var type = EnclosureType.Predator;
            var size = new EnclosureSize(20, 10, 30);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Enclosure(type, size, 0));
            Assert.Throws<ArgumentException>(() => new Enclosure(type, size, -1));
        }

        [Fact]
        public void AddAnimal_ShouldAddAnimalToEnclosure()
        {
            // Arrange
            var enclosure = new Enclosure(EnclosureType.Predator, new EnclosureSize(20, 10, 30), 5);
            var animalMock = new Mock<IAnimal>();

            // Act
            enclosure.AddAnimal(animalMock.Object);

            // Assert
            Assert.Contains(animalMock.Object, enclosure.Animals);
            Assert.Equal(1, enclosure.CurrentOccupancy);
        }

        [Fact]
        public void AddAnimal_ShouldThrowException_WhenEnclosureIsFull()
        {
            // Arrange
            var enclosure = new Enclosure(EnclosureType.Predator, new EnclosureSize(20, 10, 30), 1);
            var animalMock1 = new Mock<IAnimal>();
            var animalMock2 = new Mock<IAnimal>();

            // Act
            enclosure.AddAnimal(animalMock1.Object);

            // Assert
            Assert.Throws<InvalidOperationException>(() => enclosure.AddAnimal(animalMock2.Object));
        }

        [Fact]
        public void AddAnimal_ShouldThrowException_WhenAnimalIsAlreadyInEnclosure()
        {
            // Arrange
            var enclosure = new Enclosure(EnclosureType.Predator, new EnclosureSize(20, 10, 30), 5);
            var animalMock = new Mock<IAnimal>();

            // Act
            enclosure.AddAnimal(animalMock.Object);

            // Assert
            Assert.Throws<InvalidOperationException>(() => enclosure.AddAnimal(animalMock.Object));
        }

        [Fact]
        public void RemoveAnimal_ShouldRemoveAnimalFromEnclosure()
        {
            // Arrange
            var enclosure = new Enclosure(EnclosureType.Predator, new EnclosureSize(20, 10, 30), 5);
            var animalMock = new Mock<IAnimal>();
            enclosure.AddAnimal(animalMock.Object);

            // Act
            enclosure.RemoveAnimal(animalMock.Object);

            // Assert
            Assert.DoesNotContain(animalMock.Object, enclosure.Animals);
            Assert.Equal(0, enclosure.CurrentOccupancy);
        }

        [Fact]
        public void RemoveAnimal_ShouldThrowException_WhenThereNoAnimalsInEnclosure()
        {
            // Arrange
            var enclosure = new Enclosure(EnclosureType.Predator, new EnclosureSize(20, 10, 30), 5);
            var animalMock = new Mock<IAnimal>();

            // Assert
            Assert.Throws<InvalidOperationException>(() => enclosure.RemoveAnimal(animalMock.Object));
        }

        [Fact]
        public void RemoveAnimal_ShouldThrowException_WhenAnimalIsNotInEnclosure()
        {
            // Arrange
            var enclosure = new Enclosure(EnclosureType.Predator, new EnclosureSize(20, 10, 30), 5);
            var existingAnimalMock = new Mock<IAnimal>();
            var nonExistentAnimalMock = new Mock<IAnimal>();

            // Add an animal to the enclosure
            enclosure.AddAnimal(existingAnimalMock.Object);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => enclosure.RemoveAnimal(nonExistentAnimalMock.Object));
        }

        [Fact]
        public void Clean_ShouldOutputCorrectMessage()
        {
            // Arrange
            var enclosure = new Enclosure(EnclosureType.Predator, new EnclosureSize(20, 10, 30), 5);

            // Act
            using var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            enclosure.Clean();

            // Assert
            Assert.Contains("Enclosure is already clean.", consoleOutput.ToString());
        }

        [Fact]
        public void AddAnimal_ShouldThrowException_WhenAnimalIsNull()
        {
            // Arrange
            var enclosure = new Enclosure(EnclosureType.Predator, new EnclosureSize(20, 10, 30), 5);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => enclosure.AddAnimal(null));
        }

        [Fact]
        public void RemoveAnimal_ShouldThrowException_WhenAnimalIsNull()
        {
            // Arrange
            var enclosure = new Enclosure(EnclosureType.Predator, new EnclosureSize(20, 10, 30), 5);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => enclosure.RemoveAnimal(null));
        }

        [Fact]
        public void Animals_ShouldBeReadOnly()
        {
            // Arrange
            var enclosure = new Enclosure(EnclosureType.Predator, new EnclosureSize(20, 10, 30), 5);

            // Act & Assert
            Assert.IsAssignableFrom<IReadOnlyList<IAnimal>>(enclosure.Animals);
        }
    }
}
