using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Domain.Entities.ValueObjects
{
    /// <summary>
    /// Represents the type of an enclosure in the zoo.
    /// </summary>
    
    public sealed record EnclosureType
    {
        public string Value { get; }

        private EnclosureType(string value) => Value = value;

        public static EnclosureType Predator = new("Predator"); // Predefined value of a predator enclosure
        public static EnclosureType Herbivore = new("Herbivore"); // Predefined value of a herbivore enclosure
        public static EnclosureType Bird = new("Bird"); // Predefined value of a bird enclosure
        public static EnclosureType Aquarium = new("Aquarium"); // Predefined value of an aquarium enclosure

        /// <summary>
        /// Converts a string value to a valid enclosure type
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        
        public static EnclosureType FromString(string value)
        {
            return value.ToLower() switch
            {
                "predator" => Predator,
                "herbivore" => Herbivore,
                "bird" => Bird,
                "aquarium" => Aquarium,
                _ => throw new ArgumentException($"Invalid enclosure type value: {value}.")
            };
        }

        /// <summary>
        /// Implicitly converts an EnclosureType object to a string representation.
        /// </summary>
        /// <param name="enclosureType"></param>
        
        public static implicit operator string(EnclosureType enclosureType) => enclosureType.Value;

        /// <summary>
        /// Explicitly converts a string to an EnclosureType object.
        /// </summary>
        /// <param name="value"></param>
        
        public static explicit operator EnclosureType(string value) => FromString(value);

        public override string ToString() => Value;
        
    }
}
