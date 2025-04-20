using MoscowZooAccounting.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Services
{
    /// <summary>
    /// The class is responsible for storing zoo's inventories (items and animals)
    /// </summary>
    public class InventoryStorage: IInventoryStorageProvider
    {
        private List<IInventory> inventories;

        public List<IInventory> GetInventories { get => inventories; }

        public InventoryStorage() => inventories = new List<IInventory>();

        public void AddInventory(IInventory inventory)
        {
            inventories.Add(inventory);
        }
                
    }
}
