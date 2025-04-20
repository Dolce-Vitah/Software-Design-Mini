using MoscowZooAccounting.Animals;
using MoscowZooAccounting.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Tests
{
    public class AnimalCountInformerTests
    {
        [Fact]
        public void GetInfo_ShouldReturnExpectedString()
        {
            // Arrange
            var clinic = new VetClinic();
            var zoo = new MoscowZoo(clinic);
            var animalCountInformer = new AnimalCountInformer(zoo);
            string expectedResult = "Total number of animals at the zoo: 0";

            // Act
            zoo.AddAnimal(new Rabbit(1, 4, 7));
            zoo.AddAnimal(new Wolf(5, 3));
            string result = animalCountInformer.GetInfo();

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
