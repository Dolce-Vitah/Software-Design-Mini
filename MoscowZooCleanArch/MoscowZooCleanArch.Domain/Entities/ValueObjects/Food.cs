using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Domain.Entities.ValueObjects
{
    /// <summary>
    /// Represents the food that an animal in the zoo eats.
    /// </summary>
    
    public sealed record Food
    {
        public string Name { get; }

        public Food(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Food name cannot be null or empty.", nameof(name));
            }
            Name = name;
        }        

        /// <summary>
        /// Implicitly converts a Food object to a string representation.
        /// </summary>
        /// <param name="food"></param>

        public static implicit operator string(Food food)
        {
            if (food == null)
            {
                throw new ArgumentNullException(nameof(food), "Food cannot be null.");
            }
            return food.Name;
        }

        /// <summary>
        /// Implicitly converts a string to a Food object.
        /// </summary>
        /// <param name="name"></param>

        public static explicit operator Food(string name) => new(name);

        public override string ToString() => Name;
    }
}
