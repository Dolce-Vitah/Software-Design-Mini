using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Domain.Entities.ValueObjects
{
    /// <summary>
    /// Represents the species of an animal in the zoo.
    /// </summary>

    public sealed record Species
    {
        public string Type { get; private set; }

        public Species(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException("Species type cannot be null or empty.", nameof(type));
            }
            Type = type;
        }

        /// <summary>
        /// Implicitly converts a Species object to a string representation.
        /// </summary>
        /// <param name="species"></param>

        public static implicit operator string(Species species) => species.Type;

        /// <summary>
        /// Explicitly converts a string to a Species object.
        /// </summary>
        /// <param name="name"></param>

        public static explicit operator Species(string name) => new(name);
        public override string ToString() => Type;
    }
}
