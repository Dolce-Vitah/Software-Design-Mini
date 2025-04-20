using MoscowZooAccounting.Abstractions;
using MoscowZooAccounting.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Services
{
    /// <summary>
    /// The class ensures a new animal is healthy
    /// </summary>
    
    public class VetClinic: IClinicProvider
    {
        public VetClinic() { }

        /// <summary>
        /// The method checks if the animal's health level is above 5
        /// </summary>
        /// <param name="animal"></param>
        /// <returns>True or false</returns>
        
        public bool IsAnimalHealthy(Animal animal)
        {
            return animal.HealthLevel > 5;
        }
    }
}
