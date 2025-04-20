using Moq;
using MoscowZooCleanArch.Application.Interfaces;
using MoscowZooCleanArch.Application.Services;
using MoscowZooCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Test.ServiceTests
{
    public class EnclosureManagementServiceTest
    {
        [Fact]
        public void AddAnimalToEnclosure_ShouldAddAnimalToEnclosure()
        {
            // Arrange
            var animalId = Guid.NewGuid();
            var enclosureId = Guid.NewGuid();

            var mockAnimal = new Mock<IAnimal>();
            var mockEnclosure = new Mock<IEnclosure>();
            var mockAnimalRepository = new Mock<IAnimalRepository>();
            var mockEnclosureRepository = new Mock<IEnclosureRepository>();

            mockAnimalRepository.Setup(repo => repo.GetById(animalId)).Returns(mockAnimal.Object);
            mockEnclosureRepository.Setup(repo => repo.GetById(enclosureId)).Returns(mockEnclosure.Object);

            var service = new EnclosureManagementService(mockAnimalRepository.Object, mockEnclosureRepository.Object);

            // Act
            service.AddAnimalToEnclosure(animalId, enclosureId);

            // Assert
            mockEnclosure.Verify(e => e.AddAnimal(mockAnimal.Object), Times.Once);
        }

        [Fact]
        public void AddAnimalToEnclosure_ShouldThrowArgumentExceptionIfAnimalNotFound()
        {
            // Arrange
            var animalId = Guid.NewGuid();
            var enclosureId = Guid.NewGuid();

            var mockAnimalRepository = new Mock<IAnimalRepository>();
            var mockEnclosureRepository = new Mock<IEnclosureRepository>();

            mockAnimalRepository.Setup(repo => repo.GetById(animalId)).Returns((IAnimal)null);

            var service = new EnclosureManagementService(mockAnimalRepository.Object, mockEnclosureRepository.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.AddAnimalToEnclosure(animalId, enclosureId));
        }

        [Fact]
        public void AddAnimalToEnclosure_ShouldThrowArgumentExceptionIfEnclosureNotFound()
        {
            // Arrange
            var animalId = Guid.NewGuid();
            var enclosureId = Guid.NewGuid();

            var mockAnimal = new Mock<IAnimal>();
            var mockAnimalRepository = new Mock<IAnimalRepository>();
            var mockEnclosureRepository = new Mock<IEnclosureRepository>();

            mockAnimalRepository.Setup(repo => repo.GetById(animalId)).Returns(mockAnimal.Object);
            mockEnclosureRepository.Setup(repo => repo.GetById(enclosureId)).Returns((IEnclosure)null);

            var service = new EnclosureManagementService(mockAnimalRepository.Object, mockEnclosureRepository.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.AddAnimalToEnclosure(animalId, enclosureId));
        }

        [Fact]
        public void RemoveAnimalFromEnclosure_ShouldRemoveAnimalFromEnclosure()
        {
            // Arrange
            var animalId = Guid.NewGuid();
            var enclosureId = Guid.NewGuid();

            var mockAnimal = new Mock<IAnimal>();
            var mockEnclosure = new Mock<IEnclosure>();
            var mockAnimalRepository = new Mock<IAnimalRepository>();
            var mockEnclosureRepository = new Mock<IEnclosureRepository>();

            mockAnimalRepository.Setup(repo => repo.GetById(animalId)).Returns(mockAnimal.Object);
            mockEnclosureRepository.Setup(repo => repo.GetById(enclosureId)).Returns(mockEnclosure.Object);

            var service = new EnclosureManagementService(mockAnimalRepository.Object, mockEnclosureRepository.Object);

            // Act
            service.RemoveAnimalFromEnclosure(animalId, enclosureId);

            // Assert
            mockEnclosure.Verify(e => e.RemoveAnimal(mockAnimal.Object), Times.Once);
        }

        [Fact]
        public void RemoveAnimalFromEnclosure_ShouldThrowArgumentExceptionIfAnimalNotFound()
        {
            // Arrange
            var animalId = Guid.NewGuid();
            var enclosureId = Guid.NewGuid();

            var mockAnimalRepository = new Mock<IAnimalRepository>();
            var mockEnclosureRepository = new Mock<IEnclosureRepository>();

            mockAnimalRepository.Setup(repo => repo.GetById(animalId)).Returns((IAnimal)null);

            var service = new EnclosureManagementService(mockAnimalRepository.Object, mockEnclosureRepository.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.RemoveAnimalFromEnclosure(animalId, enclosureId));
        }

        [Fact]
        public void RemoveAnimalFromEnclosure_ShouldThrowArgumentExceptionIfEnclosureNotFound()
        {
            // Arrange
            var animalId = Guid.NewGuid();
            var enclosureId = Guid.NewGuid();

            var mockAnimal = new Mock<IAnimal>();
            var mockAnimalRepository = new Mock<IAnimalRepository>();
            var mockEnclosureRepository = new Mock<IEnclosureRepository>();

            mockAnimalRepository.Setup(repo => repo.GetById(animalId)).Returns(mockAnimal.Object);
            mockEnclosureRepository.Setup(repo => repo.GetById(enclosureId)).Returns((IEnclosure)null);

            var service = new EnclosureManagementService(mockAnimalRepository.Object, mockEnclosureRepository.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.RemoveAnimalFromEnclosure(animalId, enclosureId));
        }
    }
}
