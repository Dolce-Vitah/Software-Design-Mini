using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Abstractions
{
    /// <summary>
    /// The interface represents inventories' storage provider
    /// </summary>
    
    public interface IInventoryStorageProvider
    {
        public List<IInventory> GetInventories { get; }
    }
}
