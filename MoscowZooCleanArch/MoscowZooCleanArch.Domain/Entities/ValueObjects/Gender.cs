using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Domain.Entities.ValueObjects
{
    /// <summary>
    /// Represents gender of an animal in the zoo.
    /// </summary>

    public sealed record Gender
    {
        public string Value { get;  }

        private Gender(string value)
        {
            Value = value;
        }

        public static readonly Gender Male = new("Male"); // Predefined value of a male gender

        public static readonly Gender Female = new("Female"); // Predefined value of a female gender 

        /// <summary>
        /// Converts a string value to a valid gender
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Valid gender</returns>
        /// <exception cref="ArgumentException"></exception>

        public static Gender FromString(string value)
        {
            return value.ToLower() switch
            {
                "male" => Male,
                "female" => Female,
                _ => throw new ArgumentException($"Invalid gender value: {value}.", nameof(value))
            };
        }

        /// <summary>
        /// Implicitly converts a Gender object to string.
        /// </summary>
        /// <param name="gender"></param>
        
        public static implicit operator string(Gender gender) => gender.Value;

        /// <summary>
        /// Explicitly converts string to a Gender object.
        /// </summary>
        /// <param name="value"></param>

        public static explicit operator Gender(string value) => FromString(value);

        public override string ToString() => Value;
    }
}
