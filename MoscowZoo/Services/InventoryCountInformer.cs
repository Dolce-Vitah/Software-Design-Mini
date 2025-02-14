using MoscowZooAccounting.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Services
{
    /// <summary>
    /// The class is responsible for providing information about zoo's inventories (items and animals)
    /// </summary>
    
    public class InventoryCountInformer: IInfoProvider
    {
        private IInventoryStorageProvider InventoryStorageProvider { get; set; }

        public InventoryCountInformer(IInventoryStorageProvider inventoryStorageProvider) => InventoryStorageProvider = inventoryStorageProvider;

        public string GetInfo()
        {
            string result = "The list of the zoo's invetories:\n";

            foreach (var inventory in InventoryStorageProvider.GetInventories)
            {
                result += $"Type: {inventory.GetType().Name}, Number: {inventory.Number}\n";
            }

            return result;
        }
    }
}
