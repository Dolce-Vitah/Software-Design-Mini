using MoscowZooAccounting.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Abstractions
{
    /// <summary>
    /// The interface represents zoo's items provider
    /// </summary>
    public interface IItemsProvider
    {
        public List<Thing> GetItems { get; }
    }
}
