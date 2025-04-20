using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Domain.Entities.ValueObjects
{
    /// <summary>
    /// Represents the size of an enclosure in the zoo.
    /// </summary>

    public sealed record EnclosureSize
    {
        public int Width { get; }
        public int Height { get; }
        public int Length { get; }

        public EnclosureSize(int width, int height, int length)
        {
            if (width <= 0 || height <= 0 || length <= 0)
            {
                throw new ArgumentException("Width, height, and length must be positive integers.");
            }

            Width = width;
            Height = height;
            Length = length;
        }

        /// <summary>
        /// Calculates the volume of the enclosure.
        /// </summary>
        /// <returns></returns>

        public int CalculateVolume() => Width * Height * Length;

        public override string ToString()
        {
            return $"width: {Width}, height: {Height}, length: {Length}";
        }
    }
}
