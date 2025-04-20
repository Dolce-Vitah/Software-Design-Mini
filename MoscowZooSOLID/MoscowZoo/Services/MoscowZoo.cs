using MoscowZooAccounting.Abstractions;
using MoscowZooAccounting.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Services
{
    /// <summary>
    /// The class adds new animals and stores them
    /// </summary>
    
    public class MoscowZoo: IZoo
    {
        private IClinicProvider Clinic { get; init; }

        public event InventoryHandler? SendAnimal; 

        private List<Animal> animals;

        public List<Animal> GetAnimals { get => animals; }

        public MoscowZoo(IClinicProvider clinic)
        {
            Clinic = clinic;
            animals = new List<Animal>();
        }

        /// <summary>
        /// The method adds a new animal, only if a clinic approves
        /// </summary>
        /// <param name="newAnimal"></param>

        public void AddAnimal(Animal newAnimal)
        {
            if (Clinic.IsAnimalHealthy(newAnimal))
            {
                newAnimal.Number = UniqueNumberProvider.GetNumber();
                animals.Add(newAnimal);
                SendAnimal?.Invoke(newAnimal);
            }
        }
    }
}
