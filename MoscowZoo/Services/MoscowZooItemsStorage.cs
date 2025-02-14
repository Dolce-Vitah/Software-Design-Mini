using MoscowZooAccounting.Abstractions;
using MoscowZooAccounting.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Services
{
    /// <summary>
    /// The class is responsible for storing items that belong to the zoo
    /// </summary>
    
    public class MoscowZooItemsStorage: IItemsProvider
    {
        public event InventoryHandler? SendItem;

        private List<Thing> items;
        
        public List<Thing> GetItems { get => items; }

        public MoscowZooItemsStorage() => items = new List<Thing>();

        public void AddItem(Thing item)
        {
            items.Add(item);
            SendItem?.Invoke(item);
        }
    }
}
