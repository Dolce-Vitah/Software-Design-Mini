using MoscowZooCleanArch.Application.DataTransferObjects;
using MoscowZooCleanArch.Application.Factories;
using MoscowZooCleanArch.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Test.FactoryTests
{
    public class EnclosureFactoryTest
    {
        [Fact]
        public void CreateEnclosure_ShouldReturnEnclosureWithCorrectProperties()
        {
            // Arrange
            var enclosureDto = new CreateEnclosureDTO
            {
                Type = "Predator",
                Width = 10,
                Height = 5,
                Length = 15,
                MaxCapacity = 20
            };

            var factory = new EnclosureFactory();

            // Act
            var enclosure = factory.CreateEnclosure(enclosureDto);

            // Assert
            Assert.NotNull(enclosure);
            Assert.Equal(EnclosureType.Predator, enclosure.Type);
            Assert.Equal(10, enclosure.Size.Width);
            Assert.Equal(5, enclosure.Size.Height);
            Assert.Equal(15, enclosure.Size.Length);
            Assert.Equal(20, enclosure.MaxCapacity);
        }

        [Fact]
        public void CreateEnclosure_ShouldThrowArgumentExceptionForInvalidEnclosureType()
        {
            // Arrange
            var enclosureDto = new CreateEnclosureDTO
            {
                Type = "InvalidType", // Invalid type
                Width = 10,
                Height = 5,
                Length = 15,
                MaxCapacity = 20
            };

            var factory = new EnclosureFactory();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateEnclosure(enclosureDto));
        }

        [Fact]
        public void CreateEnclosure_ShouldThrowArgumentExceptionForNegativeDimensions()
        {
            // Arrange
            var enclosureDto = new CreateEnclosureDTO
            {
                Type = "Herbivore",
                Width = -10, // Invalid width
                Height = 5,
                Length = 15,
                MaxCapacity = 20
            };

            var factory = new EnclosureFactory();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateEnclosure(enclosureDto));
        }

        [Fact]
        public void CreateEnclosure_ShouldThrowArgumentExceptionForZeroOrNegativeMaxCapacity()
        {
            // Arrange
            var enclosureDto = new CreateEnclosureDTO
            {
                Type = "Bird",
                Width = 10,
                Height = 5,
                Length = 15,
                MaxCapacity = 0 // Invalid max capacity
            };

            var factory = new EnclosureFactory();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateEnclosure(enclosureDto));
        }
    }
}
