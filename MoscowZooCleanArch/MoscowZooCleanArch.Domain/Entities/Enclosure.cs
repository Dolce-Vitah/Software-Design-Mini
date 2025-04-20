using MoscowZooCleanArch.Domain.Entities.ValueObjects;
using MoscowZooCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Domain.Entities
{
    /// <summary>
    /// Represents an enclosure in the zoo.
    /// </summary>

    public class Enclosure: IEnclosure
    {
        public Guid ID { get; private set; } = Guid.NewGuid();

        public EnclosureType Type { get; private set; }

        public EnclosureSize Size { get; private set; }

        public int CurrentOccupancy { get; private set; } = 0;

        public int MaxCapacity { get; private set; }

        public bool IsClean { get; private set; } = true;


        private List<IAnimal> animals = new List<IAnimal>();
        public IReadOnlyList<IAnimal> Animals => animals;

        public Enclosure(EnclosureType type, EnclosureSize size, int maxCapacity)
        {
            Type = type ?? throw new ArgumentNullException("Enclosure type cannot be null.", nameof(type));
            Size = size ?? throw new ArgumentNullException("Enclosure size cannot be null.", nameof(size));
            MaxCapacity = maxCapacity > 0 ? maxCapacity : throw new ArgumentException("Max capacity must be a positive integer.", nameof(maxCapacity));
        }

        /// <summary>
        /// Adds an animal to the enclosure.
        /// </summary>
        /// <param name="animal"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>

        public void AddAnimal(IAnimal animal)
        {
            if (animal == null)
            {
                throw new ArgumentNullException(nameof(animal), "Animal cannot be null.");
            }
            if (CurrentOccupancy >= MaxCapacity)
            {
                throw new InvalidOperationException("Cannot add animal. Enclosure is at full capacity.");
            }
            if (animals.Contains(animal))
            {
                throw new InvalidOperationException("Animal is already in the enclosure.");
            }

            animals.Add(animal);
            CurrentOccupancy++;
        }

        /// <summary>
        /// Removes an animal from the enclosure.
        /// </summary>
        /// <param name="animal"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>

        public void RemoveAnimal(IAnimal animal)
        {
            if (animal == null)
            {
                throw new ArgumentNullException(nameof(animal), "Animal cannot be null.");
            }
            if (CurrentOccupancy <= 0)
            {
                throw new InvalidOperationException("Cannot remove animal. Enclosure is empty.");
            }
            if (!animals.Contains(animal))
            {
                throw new InvalidOperationException("Animal is not in the enclosure.");
            }

            animals.Remove(animal);
            CurrentOccupancy--;
        }

        /// <summary>
        /// Cleans the enclosure.
        /// </summary>

        public void Clean()
        {
            if (IsClean)
            {
                Console.WriteLine("Enclosure is already clean.");
                return;
            }
            IsClean = true;
            Console.WriteLine($"Cleaning the enclosure. Current occupancy: {CurrentOccupancy}/{MaxCapacity}");
        }

        public override string ToString()
        {
            return $"Enclosure (ID: {ID}): enclosure type: {Type}, size: ({Size}), state: {(IsClean ? "clean" : "dirty")}" +
                   $"current occupancy: {CurrentOccupancy}/{MaxCapacity}";
        }
    }
}
