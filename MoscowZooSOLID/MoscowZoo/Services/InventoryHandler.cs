using MoscowZooAccounting.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Services
{
    /// <summary>
    /// The delegate for handling inventory sendings
    /// </summary>
    /// <param name="inventory"></param>
    
    public delegate void InventoryHandler(IInventory inventory);
}
