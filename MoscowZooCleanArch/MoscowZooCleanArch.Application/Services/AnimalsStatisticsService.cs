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
    /// This class provides methods to get statistics about animals in the zoo.
    /// </summary>
    internal class AnimalsStatisticsService: IAnimalsStatisticsService
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalsStatisticsService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        /// <summary>
        /// Gets the total number of animals in the zoo.
        /// </summary>
        /// <returns></returns>

        public int GetTotalAnimalsCount()
        {
            return _animalRepository.GetAllAnimals().Count;
        }

        /// <summary>
        /// Gets the number of sick animals in the zoo.
        /// </summary>
        /// <returns></returns>

        public int GetSickAnimalsCount()
        {
            return _animalRepository.GetAllAnimals().Count(a => !a.Status);
        }

        /// <summary>
        /// Gets the number of female animals in the zoo.
        /// </summary>
        /// <returns></returns>

        public int GetFemaleAnimalsCount()
        {
            return _animalRepository.GetAllAnimals().Count(a => a.Gender == Gender.Female);
        }

        /// <summary>
        /// Gets the number of male animals
        /// </summary>
        /// <returns></returns>

        public int GetMaleAnimalsCount()
        {
            return _animalRepository.GetAllAnimals().Count(a => a.Gender == Gender.Male);
        }
    }
}
