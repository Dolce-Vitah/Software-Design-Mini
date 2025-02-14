using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Abstractions
{
    /// <summary>
    /// The interface represents live creature
    /// </summary>
    
    public interface IAlive
    {
        public int Food { get; init; }
    }
}
