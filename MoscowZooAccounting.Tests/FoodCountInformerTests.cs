using MoscowZooAccounting.Animals;
using MoscowZooAccounting.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Tests
{
    public class FoodCountInformerTests
    {
        [Fact]
        public void GetInfo_ShouldReturnExpectedString()
        {
            // Arrange
            var clinic = new VetClinic();
            var zoo = new MoscowZoo(clinic);
            var foodCountInformer = new FoodCountInformer(zoo);
            string expectedResult = "The total amount of food required per day: 10";

            // Act
            zoo.AddAnimal(new Rabbit(2, 6, 7));
            zoo.AddAnimal(new Tiger(8, 7));
            string result = foodCountInformer.GetInfo();
            
            // Assert
            Assert.Equal(expectedResult, result);   
        }

        [Fact]
        public void CountFoodPerDay_ShouldReturnExpectedValue()
        {
            // Arrange
            var clinic = new VetClinic();
            var zoo = new MoscowZoo(clinic);
            var foodCountInformer = new FoodCountInformer(zoo);
            int expectedResult = 12;

            // Act
            zoo.AddAnimal(new Monkey(3, 7, 6));
            zoo.AddAnimal(new Wolf(9, 6));
            int result = foodCountInformer.CountFoodPerDay();

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
