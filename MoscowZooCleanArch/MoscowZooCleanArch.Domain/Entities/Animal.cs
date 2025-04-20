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
    /// Represents an animal in the zoo.
    /// </summary>
    
    public class Animal: IAnimal
    {
        public Guid ID { get; private set; } = Guid.NewGuid();

        public string Name { get; private set; }

        public Species Species { get; private set; }

        public BirthDate DateOfBirth { get; private set; }

        public Gender Gender { get; private set; }

        public Food FavoriteFood { get; private set; }

        public HealthStatus Status { get; private set; }

        public Animal(string name, Species species, BirthDate date,
                      Gender gender, Food favFood, HealthStatus status)
        {
            Name = string.IsNullOrEmpty(name) ? throw new ArgumentException("Name cannot be null or empty.", nameof(name)) : name;
            Species = species ?? throw new ArgumentNullException("Species cannot be null.", nameof(species));
            DateOfBirth = date ?? throw new ArgumentNullException("Date of birth cannot be null.", nameof(date));
            Gender = gender ?? throw new ArgumentNullException("Gender cannot be null.", nameof(gender));
            FavoriteFood = favFood ?? throw new ArgumentNullException("Favorite food cannot be null.", nameof(favFood));
            Status = status ?? throw new ArgumentNullException("Health status cannot be null.", nameof(status));
        }

        /// <summary>
        /// Feeds the animal with the specified food.
        /// </summary>
        /// <param name="food"></param>

        public void Feed(Food food)
        {
            if (food == FavoriteFood)
            {
                Console.WriteLine($"{Name} is happily eating {food}.\n");
            }
            else
            {
                Console.WriteLine($"{Name} would prefer {FavoriteFood}, but is okay with {food}.\n");

            }
        }

        /// <summary>
        /// Treats the animal if it is not healthy.
        /// </summary>

        public void Treat()
        {
            if (Status)
            {
                Console.WriteLine($"{Name} is healthy and doesn't need treatment.\n");
            }
            else
            {
                Console.WriteLine($"{Name} is receiving treatment.\n");
                Status = (HealthStatus)true;
            }
        }

        /// <summary>
        /// Moves the animal to a different enclosure.
        /// </summary>

        public void MoveToEnclosure(IEnclosure from, IEnclosure to)
        {
            from.RemoveAnimal(this);
            to.AddAnimal(this);
        }

        public override string ToString()
        {
            return $"Animal's ID: {ID}, species: {Species}, name: {Name}, gender: {Gender}, date of birth: {DateOfBirth}, " +
                   $"favorite food: {FavoriteFood}, health status: {Status}";
        }
    }
}
