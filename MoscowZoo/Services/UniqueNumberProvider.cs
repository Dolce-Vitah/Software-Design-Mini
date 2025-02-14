using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Services
{
    /// <summary>
    /// The class is responsible for generating inventory numbers
    /// </summary>
    
    public static class UniqueNumberProvider
    {
        static int currentNumber = 0;

        public static int GetNumber()
        {
            return ++currentNumber;
        }
    }
}
