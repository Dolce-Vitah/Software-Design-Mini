using MoscowZooAccounting.Abstractions;
using MoscowZooAccounting.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Animals
{
    /// <summary>
    /// The abstract class for zoo animals
    /// </summary>
    
    abstract public class Animal: IAlive, IInventory
    {
        protected static readonly Random random = new Random();
        public int Food { get; init; }

        public int Number { get; set; } = 0;

        public int HealthLevel { get; init; }

        public Animal(int food, int healthLevel)
        {
            Food = food <= 0 ? random.Next(1, 15) : food;
            HealthLevel = healthLevel < 1 || healthLevel > 10 ? random.Next(1, 11) : healthLevel;
        }

        public virtual string Info()
        {
            return $"Food: {Food}, Number: {Number}, HealthLevel: {HealthLevel}";
        }
    }
}
