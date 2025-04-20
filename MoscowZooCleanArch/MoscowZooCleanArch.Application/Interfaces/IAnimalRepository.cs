using MoscowZooCleanArch.Domain.Entities;
using MoscowZooCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Application.Interfaces
{
    /// <summary>
    /// Interface for the animal repository.
    /// </summary>
    public interface IAnimalRepository
    {
        void AddAnimal(IAnimal animal);

        void DeleteAnimal(IAnimal animal);

        IAnimal? GetById(Guid id);

        IReadOnlyList<IAnimal> GetAllAnimals();
    }
}
