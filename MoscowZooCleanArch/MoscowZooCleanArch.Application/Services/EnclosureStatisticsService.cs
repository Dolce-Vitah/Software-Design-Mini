using MoscowZooCleanArch.Application.Interfaces;
using MoscowZooCleanArch.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Application.Services
{
    /// <summary>
    /// Service for retrieving statistics about enclosures in the zoo.
    /// </summary>
    
    internal class EnclosureStatisticsService: IEnclosureStatisticsService
    {
        private readonly IEnclosureRepository _enclosureRepository;

        public EnclosureStatisticsService(IEnclosureRepository enclosureRepository)
        {
            _enclosureRepository = enclosureRepository;
        }

        /// <summary>
        /// Returns the total number of enclosures in the zoo.
        /// </summary>
        /// <returns></returns>

        public int GetTotalEnclosuresCount()
        {
            return _enclosureRepository.GetAllEnclosures().Count;
        }

        /// <summary>
        /// Returns the number of empty enclosures in the zoo.
        /// </summary>
        /// <returns></returns>

        public int GetEmptyEnclosuresCount()
        {
            return _enclosureRepository.GetAllEnclosures().Count(e => e.CurrentOccupancy == 0);
        }

        /// <summary>
        /// Returns the number of enclosures for predators in the zoo.
        /// </summary>
        /// <returns></returns>

        public int GetPredatorEnclosuresCount()
        {
            return _enclosureRepository.GetAllEnclosures().Count(e => e.Type == EnclosureType.Predator);
        }

        /// <summary>
        /// Returns the number of enclosures for herbivores in the zoo.
        /// </summary>
        /// <returns></returns>

        public int GetHerbivoreEnclosuresCount()
        {
            return _enclosureRepository.GetAllEnclosures().Count(e => e.Type == EnclosureType.Herbivore);
        }

        /// <summary>
        /// Returns the number of enclosures for birds in the zoo.
        /// </summary>
        /// <returns></returns>

        public int GetBirdEnclosuresCount()
        {
            return _enclosureRepository.GetAllEnclosures().Count(e => e.Type == EnclosureType.Bird);
        }

        /// <summary>
        /// Returns the number of aquariums in the zoo.
        /// </summary>
        /// <returns></returns>

        public int GetAquaticEnclosuresCount()
        {
            return _enclosureRepository.GetAllEnclosures().Count(e => e.Type == EnclosureType.Aquarium);
        }

        /// <summary>
        /// Returns the number of clean enclosures in the zoo.
        /// </summary>
        /// <returns></returns>

        public int GetCleanEnclosuresCount()
        {
            return _enclosureRepository.GetAllEnclosures().Count(e => e.IsClean);
        }
    }
}
