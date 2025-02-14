using MoscowZooAccounting.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Abstractions
{
    /// <summary>
    /// The interface represents primitive health check-up provider
    /// </summary>
    
    public interface IClinicProvider
    {
        public bool IsAnimalHealthy(Animal animal);
    }
}
