using MoscowZooAccounting.Abstractions;
using MoscowZooAccounting.Animals;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Tests
{
    public class VetClinicTests
    {
        [Theory]
        [MemberData(nameof(GetAnimalsForVetClinic))]
        public void IsAnimalHealthy_ShouldReturnExpectedValue(Animal animal, bool expected)
        {
            // Arrange
            var clinic = Substitute.For<IClinicProvider>();
            clinic.IsAnimalHealthy(Arg.Any<Animal>()).Returns(expected);

            // Act
            bool result = clinic.IsAnimalHealthy(animal);

            // Assert
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> GetAnimalsForVetClinic()
        {
            yield return new object[]
            {
                new Monkey(3, 4, 6),
                false
            };

            yield return new object[]
            {
                new Tiger(7, 6),
                true
            };
        }    
    }
}
