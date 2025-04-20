using MoscowZooAccounting.Abstractions;
using MoscowZooAccounting.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Items
{
    /// <summary>
    /// The abstract class for zoo items
    /// </summary>
    
    abstract public class Thing: IInventory
    {
        public int Number { get; set; } = UniqueNumberProvider.GetNumber();

        public Thing() { }
    }
}
