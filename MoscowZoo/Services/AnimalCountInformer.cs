using MoscowZooAccounting.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Services
{
    /// <summary>
    /// The class is responsible for listing all zoo animals
    /// </summary>
    
    public class AnimalCountInformer: IInfoProvider
    {
        private IZoo Zoo { get; set; }
        public AnimalCountInformer(IZoo zoo) => Zoo = zoo;

        public string GetInfo()
        {
            return $"Total number of animals at the zoo: {Zoo.GetAnimals.Count()}";
        }
    }
}
