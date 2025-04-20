using MoscowZooAccounting.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Tests
{
    public class AnimalTests
    {
        [Fact]
        public void Health_Read_ShouldReturnExpectedValue()
        {
            // Arrange
            Animal animal = new Wolf(7, 9);

            // Act & Assert
            Assert.Equal(9, animal.HealthLevel);
        }

        [Fact]
        public void Health_LiesInGivenRange()
        {
            // Arrange
            Animal animal = new Rabbit(2, 11, 7);

            // Act & Assert
            Assert.NotEqual(11, animal.HealthLevel);
        }

        [Fact]
        public void InfoPredators_ShouldReturnExpectedString()
        {
            // Arrange
            Animal animal = new Wolf(7, 1);
            // Note: the number equals 0, since the animal hasn't been added to the zoo
            string expected = "Food: 7, Number: 0, HealthLevel: 1";

            // Act & Assert
            Assert.Equal(expected, animal.Info());
        }

        [Fact]
        public void InfoHerbo_ShouldReturnExpectedString()
        {
            // Arrange
            Animal animal = new Rabbit(3, 5, 7);
            // Note: the number equals 0, since the animal hasn't been added to the zoo
            string expected = "Food: 3, Number: 0, HealthLevel: 5, KindnessLevel: 7";

            // Act & Assert
            Assert.Equal(expected, animal.Info());
        }
    }
}
