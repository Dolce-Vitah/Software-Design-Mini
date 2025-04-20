using Moq;
using MoscowZooCleanArch.Application.Interfaces;
using MoscowZooCleanArch.Application.Services;
using MoscowZooCleanArch.Domain.Entities.ValueObjects;
using MoscowZooCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Test.ServiceTests
{
    public class AnimalStatisticsServiceTest
    {
        [Fact]
        public void GetTotalAnimalsCount_ShouldReturnCorrectCount()
        {
            // Arrange
            var mockRepository = new Mock<IAnimalRepository>();
            mockRepository.Setup(repo => repo.GetAllAnimals()).Returns(new List<IAnimal>
            {
                Mock.Of<IAnimal>(),
                Mock.Of<IAnimal>(),
                Mock.Of<IAnimal>()
            });

            var service = new AnimalsStatisticsService(mockRepository.Object);

            // Act
            var totalAnimals = service.GetTotalAnimalsCount();

            // Assert
            Assert.Equal(3, totalAnimals);
        }

        [Fact]
        public void GetSickAnimalsCount_ShouldReturnCorrectCount()
        {
            // Arrange
            var mockRepository = new Mock<IAnimalRepository>();
            mockRepository.Setup(repo => repo.GetAllAnimals()).Returns(new List<IAnimal>
            {
                Mock.Of<IAnimal>(a => a.Status == HealthStatus.Healthy),
                Mock.Of<IAnimal>(a => a.Status == HealthStatus.Unhealthy),
                Mock.Of<IAnimal>(a => a.Status == HealthStatus.Unhealthy)
            });

            var service = new AnimalsStatisticsService(mockRepository.Object);

            // Act
            var sickAnimals = service.GetSickAnimalsCount();

            // Assert
            Assert.Equal(2, sickAnimals);
        }

        [Fact]
        public void GetFemaleAnimalsCount_ShouldReturnCorrectCount()
        {
            // Arrange
            var mockRepository = new Mock<IAnimalRepository>();
            mockRepository.Setup(repo => repo.GetAllAnimals()).Returns(new List<IAnimal>
            {
                Mock.Of<IAnimal>(a => a.Gender == Gender.Female),
                Mock.Of<IAnimal>(a => a.Gender == Gender.Male),
                Mock.Of<IAnimal>(a => a.Gender == Gender.Female)
            });

            var service = new AnimalsStatisticsService(mockRepository.Object);

            // Act
            var femaleAnimals = service.GetFemaleAnimalsCount();

            // Assert
            Assert.Equal(2, femaleAnimals);
        }

        [Fact]
        public void GetMaleAnimalsCount_ShouldReturnCorrectCount()
        {
            // Arrange
            var mockRepository = new Mock<IAnimalRepository>();
            mockRepository.Setup(repo => repo.GetAllAnimals()).Returns(new List<IAnimal>
            {
                Mock.Of<IAnimal>(a => a.Gender == Gender.Female),
                Mock.Of<IAnimal>(a => a.Gender == Gender.Male),
                Mock.Of<IAnimal>(a => a.Gender == Gender.Male)
            });

            var service = new AnimalsStatisticsService(mockRepository.Object);

            // Act
            var maleAnimals = service.GetMaleAnimalsCount();

            // Assert
            Assert.Equal(2, maleAnimals);
        }
    }
}
