using MoscowZooCleanArch.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Test.ValueObjectTests
{
    public class EnclosureSizeTest
    {
        [Fact]
        public void EnclosureSize_Constructor_ShouldSetDimensionsCorrectly()
        {
            // Arrange
            var width = 10;
            var height = 20;
            var length = 30;

            // Act
            var enclosureSize = new EnclosureSize(width, height, length);

            // Assert
            Assert.Equal(width, enclosureSize.Width);
            Assert.Equal(height, enclosureSize.Height);
            Assert.Equal(length, enclosureSize.Length); 
        }

        [Fact]
        public void EnclosureSize_Constructor_ShouldThrowArgumentExceptionForNegativeDimensions()
        {
            // Arrange
            var negativeWidth = -5;
            var negativeHeight = -10;
            var negativeLength = -15;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new EnclosureSize(negativeWidth, 10, 15));
            Assert.Throws<ArgumentException>(() => new EnclosureSize(10, negativeHeight, 15));
            Assert.Throws<ArgumentException>(() => new EnclosureSize(10, 5, negativeLength));
        }

        [Fact]
        public void EnclosureSize_Volume_ShouldBeCalculatedCorrectly()
        {
            // Arrange
            var width = 15;
            var height = 25;
            var length = 5; 

            // Act
            var enclosureSize = new EnclosureSize(width, height, length);

            // Assert
            Assert.Equal(1875, enclosureSize.CalculateVolume()); // Assuming Area = Width * Height
        }

        [Fact]
        public void EnclosureSize_Constructor_ShouldThrowArgumentExceptionForZeroDimensions()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new EnclosureSize(0, 10, 5));
            Assert.Throws<ArgumentException>(() => new EnclosureSize(10, 0, 5));
            Assert.Throws<ArgumentException>(() => new EnclosureSize(10, 5, 0));
        }
    }
}
