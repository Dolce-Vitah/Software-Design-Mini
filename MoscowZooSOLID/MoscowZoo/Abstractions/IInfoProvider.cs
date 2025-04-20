using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Abstractions
{
    /// <summary>
    /// The iterface represents information provider
    /// </summary>
    
    public interface IInfoProvider
    {
        public string GetInfo();
    }
}
