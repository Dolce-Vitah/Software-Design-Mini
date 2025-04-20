using MoscowZooAccounting.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Abstractions
{
    /// <summary>
    /// The interface represents animals' storage provider
    /// </summary>
    
    public interface IZoo
    {
        public List<Animal> GetAnimals { get; }
    }
}
