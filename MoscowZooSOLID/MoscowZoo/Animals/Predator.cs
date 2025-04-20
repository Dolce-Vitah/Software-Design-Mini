using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Animals
{
    /// <summary>
    /// The abstract class for zoo predators
    /// </summary>
    
    abstract public class Predator: Animal
    {
        public Predator(int food, int healthLevel): base(food, healthLevel) { }
    }
}
