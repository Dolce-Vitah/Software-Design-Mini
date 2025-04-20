using MoscowZooAccounting.Abstractions;
using MoscowZooAccounting.Animals;
using MoscowZooAccounting.Services;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Tests
{
    public class KindAnimalsListInformerTests
    {
        [Fact]
        public void GetInfo_ShouldReturnNone()
        {
            // Arrange
            var clinic = new VetClinic();
            var zoo = new MoscowZoo(clinic);            
            var kindAnimalsListInformer = new KindAnimalsListInformer(zoo);
            string expectedResult = "Animals to be added to the petting zoo: None\n";

            // Act
            zoo.AddAnimal(new Tiger(6, 7));
            zoo.AddAnimal(new Wolf(5, 6));
            string result = kindAnimalsListInformer.GetInfo();

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GetInfo_ShouldReturnList()
        {
            // Arrange
            var clinic = new VetClinic();
            var zoo = new MoscowZoo(clinic);
            var kindAnimalsListInformer = new KindAnimalsListInformer(zoo);
            string expectedResult = "Animals to be added to the petting zoo: \n" +
                "Type: Rabbit, Food: 2, Number: 1, HealthLevel: 6, KindnessLevel: 7\n" +
                "Type: Monkey, Food: 3, Number: 2, HealthLevel: 7, KindnessLevel: 7\n";

            // Act
            zoo.AddAnimal(new Rabbit(2, 6, 7));
            zoo.AddAnimal(new Monkey(3, 7, 7));
            string result = kindAnimalsListInformer.GetInfo();

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [MemberData(nameof(GetAnimalsForTest))]
        public void GetKindHerbos_ShouldReturnExpectedValue(List<Animal> animals, int expectedCount)
        {
            // Arrange
            var clinic = new VetClinic();
            var zoo = new MoscowZoo(clinic);
            var kindAnimalsListInformer = new KindAnimalsListInformer(zoo);

            // Act
            animals.ForEach(animal => zoo.AddAnimal(animal));
            int result = kindAnimalsListInformer.GetKindHerbos().Count;

            // Assert
            Assert.Equal(expectedCount, result);
        }

        public static IEnumerable<object[]> GetAnimalsForTest()
        {
            yield return new object[]
            {
                new List<Animal>()
                {
                    new Tiger(8, 8),
                    new Monkey(3, 7, 5)
                },
                0
            };

            yield return new object[]
            {
                new List<Animal>()
                {
                    new Rabbit(2, 6, 7),
                    new Wolf(9, 7)
                },
                1
            };
        }
    }
}
