using MoscowZooCleanArch.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Application.Services
{
    /// <summary>
    /// Service for managing enclosure maintenance in the zoo.
    /// </summary>
    internal class EnclosureManagementService: IEnclosureManagementService
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IEnclosureRepository _enclosureRepository;

        public EnclosureManagementService(IAnimalRepository animalRepository, IEnclosureRepository enclosureRepository)
        {
            _animalRepository = animalRepository;
            _enclosureRepository = enclosureRepository;
        }

        /// <summary>
        /// Adds an animal to an enclosure.
        /// </summary>
        /// <param name="animalId"></param>
        /// <param name="enclosureId"></param>
        /// <exception cref="ArgumentException"></exception>

        public void AddAnimalToEnclosure(Guid animalId, Guid enclosureId)
        {
            var animal = _animalRepository.GetById(animalId);
            var enclosure = _enclosureRepository.GetById(enclosureId);
            if (animal == null || enclosure == null)
            {
                throw new ArgumentException("Animal or enclosure not found.");
            }
            enclosure.AddAnimal(animal);
        }

        /// <summary>
        /// Removes an animal from an enclosure.
        /// </summary>
        /// <param name="animalId"></param>
        /// <param name="enclosureId"></param>
        /// <exception cref="ArgumentException"></exception>

        public void RemoveAnimalFromEnclosure(Guid animalId, Guid enclosureId)
        {
            var animal = _animalRepository.GetById(animalId);
            var enclosure = _enclosureRepository.GetById(enclosureId);
            if (animal == null || enclosure == null)
            {
                throw new ArgumentException("Animal or enclosure not found.");
            }
            enclosure.RemoveAnimal(animal);
        }
    }
}
