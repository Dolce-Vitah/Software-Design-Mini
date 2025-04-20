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
    public class EnclosureStatisticsServiceTest
    {
        [Fact]
        public void GetTotalEnclosuresCount_ShouldReturnCorrectCount()
        {
            // Arrange
            var mockEnclosureRepository = new Mock<IEnclosureRepository>();
            mockEnclosureRepository.Setup(repo => repo.GetAllEnclosures()).Returns(new List<IEnclosure>
            {
                Mock.Of<IEnclosure>(),
                Mock.Of<IEnclosure>(),
                Mock.Of<IEnclosure>()
            });

            var service = new EnclosureStatisticsService(mockEnclosureRepository.Object);

            // Act
            var totalEnclosures = service.GetTotalEnclosuresCount();

            // Assert
            Assert.Equal(3, totalEnclosures);
        }

        [Fact]
        public void GetEmptyEnclosuresCount_ShouldReturnCorrectCount()
        {
            // Arrange
            var mockEnclosureRepository = new Mock<IEnclosureRepository>();
            mockEnclosureRepository.Setup(repo => repo.GetAllEnclosures()).Returns(new List<IEnclosure>
            {
                Mock.Of<IEnclosure>(e => e.CurrentOccupancy == 0),
                Mock.Of<IEnclosure>(e => e.CurrentOccupancy == 5),
                Mock.Of<IEnclosure>(e => e.CurrentOccupancy == 0)
            });

            var service = new EnclosureStatisticsService(mockEnclosureRepository.Object);

            // Act
            var emptyEnclosures = service.GetEmptyEnclosuresCount();

            // Assert
            Assert.Equal(2, emptyEnclosures);
        }

        [Fact]
        public void GetPredatorEnclosuresCount_ShouldReturnCorrectCount()
        {
            // Arrange
            var mockEnclosureRepository = new Mock<IEnclosureRepository>();
            mockEnclosureRepository.Setup(repo => repo.GetAllEnclosures()).Returns(new List<IEnclosure>
            {
                Mock.Of<IEnclosure>(e => e.Type == EnclosureType.Predator),
                Mock.Of<IEnclosure>(e => e.Type == EnclosureType.Herbivore),
                Mock.Of<IEnclosure>(e => e.Type == EnclosureType.Predator)
            });

            var service = new EnclosureStatisticsService(mockEnclosureRepository.Object);

            // Act
            var predatorEnclosures = service.GetPredatorEnclosuresCount();

            // Assert
            Assert.Equal(2, predatorEnclosures);
        }

        [Fact]
        public void GetHerbivoreEnclosuresCount_ShouldReturnCorrectCount()
        {
            // Arrange
            var mockEnclosureRepository = new Mock<IEnclosureRepository>();
            mockEnclosureRepository.Setup(repo => repo.GetAllEnclosures()).Returns(new List<IEnclosure>
            {
                Mock.Of<IEnclosure>(e => e.Type == EnclosureType.Herbivore),
                Mock.Of<IEnclosure>(e => e.Type == EnclosureType.Herbivore),
                Mock.Of<IEnclosure>(e => e.Type == EnclosureType.Predator)
            });

            var service = new EnclosureStatisticsService(mockEnclosureRepository.Object);

            // Act
            var herbivoreEnclosures = service.GetHerbivoreEnclosuresCount();

            // Assert
            Assert.Equal(2, herbivoreEnclosures);
        }

        [Fact]
        public void GetBirdEnclosuresCount_ShouldReturnCorrectCount()
        {
            // Arrange
            var mockEnclosureRepository = new Mock<IEnclosureRepository>();
            mockEnclosureRepository.Setup(repo => repo.GetAllEnclosures()).Returns(new List<IEnclosure>
            {
                Mock.Of<IEnclosure>(e => e.Type == EnclosureType.Bird),
                Mock.Of<IEnclosure>(e => e.Type == EnclosureType.Herbivore),
                Mock.Of<IEnclosure>(e => e.Type == EnclosureType.Bird)
            });

            var service = new EnclosureStatisticsService(mockEnclosureRepository.Object);

            // Act
            var birdEnclosures = service.GetBirdEnclosuresCount();

            // Assert
            Assert.Equal(2, birdEnclosures);
        }

        [Fact]
        public void GetAquaticEnclosuresCount_ShouldReturnCorrectCount()
        {
            // Arrange
            var mockEnclosureRepository = new Mock<IEnclosureRepository>();
            mockEnclosureRepository.Setup(repo => repo.GetAllEnclosures()).Returns(new List<IEnclosure>
            {
                Mock.Of<IEnclosure>(e => e.Type == EnclosureType.Aquarium),
                Mock.Of<IEnclosure>(e => e.Type == EnclosureType.Herbivore),
                Mock.Of<IEnclosure>(e => e.Type == EnclosureType.Aquarium)
            });

            var service = new EnclosureStatisticsService(mockEnclosureRepository.Object);

            // Act
            var aquaticEnclosures = service.GetAquaticEnclosuresCount();

            // Assert
            Assert.Equal(2, aquaticEnclosures);
        }

        [Fact]
        public void GetCleanEnclosuresCount_ShouldReturnCorrectCount()
        {
            // Arrange
            var mockEnclosureRepository = new Mock<IEnclosureRepository>();
            mockEnclosureRepository.Setup(repo => repo.GetAllEnclosures()).Returns(new List<IEnclosure>
            {
                Mock.Of<IEnclosure>(e => e.IsClean == true),
                Mock.Of<IEnclosure>(e => e.IsClean == false),
                Mock.Of<IEnclosure>(e => e.IsClean == true)
            });

            var service = new EnclosureStatisticsService(mockEnclosureRepository.Object);

            // Act
            var cleanEnclosures = service.GetCleanEnclosuresCount();

            // Assert
            Assert.Equal(2, cleanEnclosures);
        }
    }
}
