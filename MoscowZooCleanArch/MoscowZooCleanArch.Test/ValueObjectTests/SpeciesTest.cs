using MoscowZooCleanArch.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Test.ValueObjectTests
{
    public class SpeciesTest
    {
        [Fact]
        public void Species_Constructor_ShouldSetTypeCorrectly()
        {
            // Arrange
            var speciesType = "Lion";

            // Act
            var species = new Species(speciesType);

            // Assert
            Assert.Equal(speciesType, species.Type);
        }

        [Fact]
        public void Species_Constructor_ShouldThrowArgumentExceptionForNullOrEmptyType()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Species(null));
            Assert.Throws<ArgumentException>(() => new Species(string.Empty));
            Assert.Throws<ArgumentException>(() => new Species("   "));
        }

        [Fact]
        public void Species_ImplicitConversionToString_ShouldReturnCorrectType()
        {
            // Arrange
            var speciesType = "Elephant";
            var species = new Species(speciesType);

            // Act
            string result = species;

            // Assert
            Assert.Equal(speciesType, result);
        }

        [Fact]
        public void Species_ExplicitConversionFromString_ShouldCreateSpecies()
        {
            // Arrange
            var speciesType = "Giraffe";

            // Act
            var species = (Species)speciesType;

            // Assert
            Assert.Equal(speciesType, species.Type);
        }

        [Fact]
        public void Species_ToString_ShouldReturnType()
        {
            // Arrange
            var speciesType = "Zebra";
            var species = new Species(speciesType);

            // Act
            var result = species.ToString();

            // Assert
            Assert.Equal(speciesType, result);
        }
    }
}
