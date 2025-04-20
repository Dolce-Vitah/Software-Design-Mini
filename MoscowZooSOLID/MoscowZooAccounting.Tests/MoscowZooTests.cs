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
    public class MoscowZooTests
    {
        [Theory]
        [MemberData(nameof(GetAnimalsForAddAnimalTest))]
        public void AddAnimal_CheckAddsAnimals(List<Animal> animals, int expectedCount)
        {
            // Arrange
            var clinic = new VetClinic();
            var zoo = new MoscowZoo(clinic);

            // Act
            animals.ForEach(animal => zoo.AddAnimal(animal));

            // Assert
            Assert.Equal(expectedCount, zoo.GetAnimals.Count);
        }

        public static IEnumerable<object[]> GetAnimalsForAddAnimalTest()
        {
            yield return new object[]
            {
                new List<Animal>()
                {
                    new Monkey(2, 4, 5),
                    new Tiger(9, 7)
                },
                1
            };

            yield return new object[]
            {
                new List<Animal>()
                {
                    new Rabbit(1, 3, 7),
                    new Wolf(6, 3)
                },
                0
            };

            yield return new object[]
            {
                new List<Animal>()
                {
                    new Tiger(10, 8),
                    new Rabbit(3, 7, 8)
                },
                2
            };
        }
    }
}
