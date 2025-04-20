using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Abstractions
{
    /// <summary>
    /// The interface represents inventorised objects
    /// </summary>
    
    public interface IInventory
    {
        public int Number { get; set; }
    }
}
