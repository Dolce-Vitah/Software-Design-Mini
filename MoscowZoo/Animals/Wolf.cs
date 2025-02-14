using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Animals
{
    public class Wolf: Predator
    {
        public Wolf(int food, int healthLevel)
            : base(food, healthLevel) { }
    }
}
