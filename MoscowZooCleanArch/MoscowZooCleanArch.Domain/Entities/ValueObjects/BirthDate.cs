using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Domain.Entities.ValueObjects
{
    /// <summary>
    /// Represents the birth date of an animal in the zoo.
    /// </summary>

    public sealed record BirthDate
    {
        public DateTime Value { get; private set; }
        public BirthDate(DateTime date)
        {
            if (date > DateTime.Now)
            {
                throw new ArgumentException("Birth date cannot be in the future.", nameof(date));
            }
            Value = date;
        }

        /// <summary>
        /// Calculates the age of the animal based on the birth date.
        /// </summary>
        /// <returns></returns>

        public int GetAge()
        {
            var today = DateTime.UtcNow;
            var age = today.Year - Value.Year;

            if (Value.Date > today.AddYears(-age)) 
            {
                age--;
            }

            return age;
        }

        /// <summary>
        /// Implicitly converts a BirthDate object to a DateTime representation.
        /// </summary>
        /// <param name="birthDate"></param>

        public static implicit operator DateTime(BirthDate birthDate) => birthDate.Value;

        /// <summary>
        /// Implicitly converts a DateTime to a BirthDate object.
        /// </summary>
        /// <param name="date"></param>
        
        public static explicit operator BirthDate(DateTime date) => new(date);

        public override string ToString() => Value.ToString("yyyy-MM-dd");
    }
}
