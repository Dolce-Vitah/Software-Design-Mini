using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Animals
{
    public class Monkey: Herbo
    {
        public Monkey(int food, int healthLevel, int kindness) 
            : base(food, healthLevel, kindness) { }
    }
}
