using MoscowZooCleanArch.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Test.ValueObjectTests
{
    public class BirthDateTest
    {
        [Fact]
        public void BirthDate_Constructor_ShouldSetDateCorrectly()
        {
            // Arrange
            var validDate = DateTime.UtcNow.AddYears(-5);

            // Act
            var birthDate = new BirthDate(validDate);

            // Assert
            Assert.Equal(validDate, birthDate.Value);
        }

        [Fact]
        public void BirthDate_Constructor_ShouldThrowArgumentExceptionForFutureDate()
        {
            // Arrange
            var futureDate = DateTime.UtcNow.AddDays(1);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new BirthDate(futureDate));
            Assert.Equal("Birth date cannot be in the future. (Parameter 'date')", exception.Message);
        }

        [Fact]
        public void BirthDate_GetAge_ShouldReturnCorrectAge()
        {
            // Arrange
            var birthDateValue = DateTime.UtcNow.AddYears(-10).AddDays(-1); // 10 years and 1 day ago
            var birthDate = new BirthDate(birthDateValue);

            // Act
            var age = birthDate.GetAge();

            // Assert
            Assert.Equal(10, age);
        }

        [Fact]
        public void BirthDate_GetAge_ShouldAccountForUpcomingBirthday()
        {
            // Arrange
            var birthDateValue = DateTime.UtcNow.AddYears(-10).AddDays(1); // 10 years minus 1 day ago
            var birthDate = new BirthDate(birthDateValue);

            // Act
            var age = birthDate.GetAge();

            // Assert
            Assert.Equal(9, age); // Birthday hasn't occurred yet this year
        }

        [Fact]
        public void BirthDate_ImplicitConversionToDateTime_ShouldReturnCorrectDate()
        {
            // Arrange
            var validDate = DateTime.UtcNow.AddYears(-5);
            var birthDate = new BirthDate(validDate);

            // Act
            DateTime dateTime = birthDate;

            // Assert
            Assert.Equal(validDate, dateTime);
        }

        [Fact]
        public void BirthDate_ExplicitConversionFromDateTime_ShouldCreateBirthDate()
        {
            // Arrange
            var validDate = DateTime.UtcNow.AddYears(-5);

            // Act
            var birthDate = (BirthDate)validDate;

            // Assert
            Assert.Equal(validDate, birthDate.Value);
        }

        [Fact]
        public void BirthDate_ToString_ShouldReturnFormattedDate()
        {
            // Arrange
            var validDate = new DateTime(2010, 5, 15);
            var birthDate = new BirthDate(validDate);

            // Act
            var result = birthDate.ToString();

            // Assert
            Assert.Equal("2010-05-15", result);
        }
    }
}
