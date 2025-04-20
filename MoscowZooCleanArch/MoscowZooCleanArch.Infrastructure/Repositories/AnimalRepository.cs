using MoscowZooCleanArch.Application.Interfaces;
using MoscowZooCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Infrastructure.Repositories
{
    /// <summary>
    /// This class provides methods to manage animals in the zoo.
    /// </summary>

    public class AnimalRepository : IAnimalRepository
    {
        private List<IAnimal> _animals = new List<IAnimal>();

        public void AddAnimal(IAnimal animal)
        {
            if (animal == null)
            {
                throw new ArgumentNullException("Animal cannot be null", nameof(animal));
            }
            if (!_animals.Contains(animal))
            {
                _animals.Add(animal);
            }
        }

        public void DeleteAnimal(IAnimal animal)
        {
            if (animal == null)
            {
                throw new ArgumentNullException("Animal cannot be null", nameof(animal));
            }
            if (_animals.Contains(animal))
            {
                _animals.Remove(animal);
            }
        }

        public IAnimal? GetById(Guid id)
        {
            return _animals.FirstOrDefault(a => a.ID == id);
        }

        public IReadOnlyList<IAnimal> GetAllAnimals()
        {
            return _animals.AsReadOnly();
        }
    }
}
