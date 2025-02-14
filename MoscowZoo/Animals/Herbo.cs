using MoscowZooAccounting.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Animals
{
    /// <summary>
    /// The abstract class for herbivore zoo animals
    /// </summary>
    
    abstract public class Herbo: Animal
    {
        public int KindnessLevel { get; init; }

        public Herbo(int food, int healthLevel, int kindness): base(food, healthLevel)
        {
            KindnessLevel = kindness < 1 || kindness > 10 ? random.Next(1, 11) : kindness;
        }

        public override string Info()
        {
            return base.Info() + $", KindnessLevel: {KindnessLevel}";
        }
    }
}
