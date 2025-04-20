using MoscowZooCleanArch.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Test.ValueObjectTests
{
    public class FoodTest
    {
        [Fact]
        public void Food_Constructor_ShouldSetNameCorrectly()
        {
            // Arrange
            var foodName = "Meat";

            // Act
            var food = new Food(foodName);

            // Assert
            Assert.Equal(foodName, food.Name);
        }

        [Fact]
        public void Food_Constructor_ShouldThrowArgumentExceptionForNullOrEmptyName()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Food(null));
            Assert.Throws<ArgumentException>(() => new Food(string.Empty));
        }
    }
}
