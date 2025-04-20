using MoscowZooCleanArch.Application.Interfaces;
using MoscowZooCleanArch.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Application.Services
{
    /// <summary>
    /// Service for transferring animals between enclosures.
    /// </summary>
    
    internal class AnimalTransferService: IAnimalTransferService
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IEnclosureRepository _enclosureRepository;
        private readonly IDomainEventService _domainEventService;

        public AnimalTransferService(IAnimalRepository animalRepository, 
                                     IEnclosureRepository enclosureRepository, IDomainEventService domainEventService)
        {
            _animalRepository = animalRepository;
            _enclosureRepository = enclosureRepository;
            _domainEventService = domainEventService;
        }

        /// <summary>
        /// Transfers an animal from one enclosure to another.
        /// </summary>
        /// <param name="animalId"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <exception cref="ArgumentException"></exception>

        public void TransferAnimal(Guid animalId, Guid from, Guid to)
        {
            var animal = _animalRepository.GetById(animalId);
            var oldEnclosure = _enclosureRepository.GetById(from);
            var newEnclosure = _enclosureRepository.GetById(to);
            if (animal == null || newEnclosure == null || oldEnclosure == null)
            {
                throw new ArgumentException("Animal or enclosure not found.");
            }
            
            animal.MoveToEnclosure(oldEnclosure, newEnclosure);
            _domainEventService.Raise(new AnimalMovedEvent(animal, oldEnclosure, newEnclosure, DateTime.UtcNow));
        }
    }
}
