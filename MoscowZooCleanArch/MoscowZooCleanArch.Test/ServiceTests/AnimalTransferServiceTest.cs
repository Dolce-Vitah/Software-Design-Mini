using Moq;
using MoscowZooCleanArch.Application.Interfaces;
using MoscowZooCleanArch.Application.Services;
using MoscowZooCleanArch.Domain.Events;
using MoscowZooCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Test.ServiceTests
{
    public class AnimalTransferServiceTest
    {
        [Fact]
        public void TransferAnimal_ShouldTransferAnimalAndRaiseEvent()
        {
            // Arrange
            var animalId = Guid.NewGuid();
            var fromEnclosureId = Guid.NewGuid();
            var toEnclosureId = Guid.NewGuid();

            var mockAnimal = new Mock<IAnimal>();
            var mockFromEnclosure = new Mock<IEnclosure>();
            var mockToEnclosure = new Mock<IEnclosure>();
            var mockAnimalRepository = new Mock<IAnimalRepository>();
            var mockEnclosureRepository = new Mock<IEnclosureRepository>();
            var mockDomainEventService = new Mock<IDomainEventService>();

            mockAnimalRepository.Setup(repo => repo.GetById(animalId)).Returns(mockAnimal.Object);
            mockEnclosureRepository.Setup(repo => repo.GetById(fromEnclosureId)).Returns(mockFromEnclosure.Object);
            mockEnclosureRepository.Setup(repo => repo.GetById(toEnclosureId)).Returns(mockToEnclosure.Object);

            var service = new AnimalTransferService(
                mockAnimalRepository.Object,
                mockEnclosureRepository.Object,
                mockDomainEventService.Object
            );

            // Act
            service.TransferAnimal(animalId, fromEnclosureId, toEnclosureId);

            // Assert
            mockAnimal.Verify(a => a.MoveToEnclosure(mockFromEnclosure.Object, mockToEnclosure.Object), Times.Once);
            mockDomainEventService.Verify(d => d.Raise(It.IsAny<AnimalMovedEvent>()), Times.Once);
        }

        [Fact]
        public void TransferAnimal_ShouldThrowArgumentExceptionIfAnimalNotFound()
        {
            // Arrange
            var animalId = Guid.NewGuid();
            var fromEnclosureId = Guid.NewGuid();
            var toEnclosureId = Guid.NewGuid();

            var mockAnimalRepository = new Mock<IAnimalRepository>();
            var mockEnclosureRepository = new Mock<IEnclosureRepository>();
            var mockDomainEventService = new Mock<IDomainEventService>();

            mockAnimalRepository.Setup(repo => repo.GetById(animalId)).Returns((IAnimal)null);

            var service = new AnimalTransferService(
                mockAnimalRepository.Object,
                mockEnclosureRepository.Object,
                mockDomainEventService.Object
            );

            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.TransferAnimal(animalId, fromEnclosureId, toEnclosureId));
        }

        [Fact]
        public void TransferAnimal_ShouldThrowArgumentExceptionIfFromEnclosureNotFound()
        {
            // Arrange
            var animalId = Guid.NewGuid();
            var fromEnclosureId = Guid.NewGuid();
            var toEnclosureId = Guid.NewGuid();

            var mockAnimal = new Mock<IAnimal>();
            var mockAnimalRepository = new Mock<IAnimalRepository>();
            var mockEnclosureRepository = new Mock<IEnclosureRepository>();
            var mockDomainEventService = new Mock<IDomainEventService>();

            mockAnimalRepository.Setup(repo => repo.GetById(animalId)).Returns(mockAnimal.Object);
            mockEnclosureRepository.Setup(repo => repo.GetById(fromEnclosureId)).Returns((IEnclosure)null);

            var service = new AnimalTransferService(
                mockAnimalRepository.Object,
                mockEnclosureRepository.Object,
                mockDomainEventService.Object
            );

            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.TransferAnimal(animalId, fromEnclosureId, toEnclosureId));
        }

        [Fact]
        public void TransferAnimal_ShouldThrowArgumentExceptionIfToEnclosureNotFound()
        {
            // Arrange
            var animalId = Guid.NewGuid();
            var fromEnclosureId = Guid.NewGuid();
            var toEnclosureId = Guid.NewGuid();

            var mockAnimal = new Mock<IAnimal>();
            var mockFromEnclosure = new Mock<IEnclosure>();
            var mockAnimalRepository = new Mock<IAnimalRepository>();
            var mockEnclosureRepository = new Mock<IEnclosureRepository>();
            var mockDomainEventService = new Mock<IDomainEventService>();

            mockAnimalRepository.Setup(repo => repo.GetById(animalId)).Returns(mockAnimal.Object);
            mockEnclosureRepository.Setup(repo => repo.GetById(fromEnclosureId)).Returns(mockFromEnclosure.Object);
            mockEnclosureRepository.Setup(repo => repo.GetById(toEnclosureId)).Returns((IEnclosure)null);

            var service = new AnimalTransferService(
                mockAnimalRepository.Object,
                mockEnclosureRepository.Object,
                mockDomainEventService.Object
            );

            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.TransferAnimal(animalId, fromEnclosureId, toEnclosureId));
        }
    }
}
