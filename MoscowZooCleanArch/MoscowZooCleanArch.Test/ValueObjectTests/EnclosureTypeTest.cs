using MoscowZooCleanArch.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Test.ValueObjectTests
{
    public class EnclosureTypeTest
    {
        [Fact]
        public void PredefinedValues_ShouldBeInitializedCorrectly()
        {
            // Assert
            Assert.Equal("Predator", EnclosureType.Predator.Value);
            Assert.Equal("Herbivore", EnclosureType.Herbivore.Value);
            Assert.Equal("Bird", EnclosureType.Bird.Value);
            Assert.Equal("Aquarium", EnclosureType.Aquarium.Value);
        }

        [Theory]
        [InlineData("Predator", "Predator")]
        [InlineData("Herbivore", "Herbivore")]
        [InlineData("Bird", "Bird")]
        [InlineData("Aquarium", "Aquarium")]
        public void FromString_ShouldReturnCorrectEnclosureType_ForValidInput(string input, string expected)
        {
            // Act
            var result = EnclosureType.FromString(input);

            // Assert
            Assert.Equal(expected, result.Value);
        }

        [Theory]
        [InlineData("predator", "Predator")]
        [InlineData("herbivore", "Herbivore")]
        [InlineData("bird", "Bird")]
        [InlineData("aquarium", "Aquarium")]
        public void FromString_ShouldBeCaseInsensitive(string input, string expected)
        {
            // Act
            var result = EnclosureType.FromString(input);

            // Assert
            Assert.Equal(expected, result.Value);
        }

        [Fact]
        public void FromString_ShouldThrowException_ForInvalidInput()
        {
            // Arrange
            var invalidInput = "InvalidType";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => EnclosureType.FromString(invalidInput));
            Assert.Equal($"Invalid enclosure type value: {invalidInput}.", exception.Message);
        }

        [Fact]
        public void ImplicitConversionToString_ShouldReturnCorrectValue()
        {
            // Arrange
            var enclosureType = EnclosureType.Predator;

            // Act
            string result = enclosureType;

            // Assert
            Assert.Equal("Predator", result);
        }

        [Theory]
        [InlineData("Predator", "Predator")]
        [InlineData("Herbivore", "Herbivore")]
        [InlineData("Bird", "Bird")]
        [InlineData("Aquarium", "Aquarium")]
        public void ExplicitConversionFromString_ShouldReturnCorrectEnclosureType(string input, string expected)
        {
            // Act
            var result = (EnclosureType)input;

            // Assert
            Assert.Equal(expected, result.Value);
        }

        [Fact]
        public void ExplicitConversionFromString_ShouldThrowException_ForInvalidInput()
        {
            // Arrange
            var invalidInput = "InvalidType";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => (EnclosureType)invalidInput);
            Assert.Equal($"Invalid enclosure type value: {invalidInput}.", exception.Message);
        }

        [Fact]
        public void ToString_ShouldReturnCorrectValue()
        {
            // Arrange
            var enclosureType = EnclosureType.Predator;

            // Act
            var result = enclosureType.ToString();

            // Assert
            Assert.Equal("Predator", result);
        }
    }
}
