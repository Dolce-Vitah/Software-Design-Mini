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
    /// The class is responsible for forming a list of animals that be put in a petting zoo
    /// </summary>
    
    public class KindAnimalsListInformer: IInfoProvider
    {
        private IZoo Zoo { get; set; }
        public KindAnimalsListInformer(IZoo zoo) => Zoo = zoo;

        public string GetInfo()
        {
            List<Herbo> kindHerbosList = GetKindHerbos();

            string result = "Animals to be added to the petting zoo: " + (kindHerbosList.Count == 0 ? "None\n" : "\n");

            foreach (Herbo herbo in kindHerbosList)
            {
                result += $"Type: {herbo.GetType().Name}, " + herbo.Info() + "\n";
            }

            return result;
        }

        /// <summary>
        /// The method filters animals and picks only kind enough
        /// </summary>
        /// <returns>A list of kind animals</returns>

        public List<Herbo> GetKindHerbos()
        {
            return Zoo.GetAnimals.OfType<Herbo>().Where(herbo => herbo.KindnessLevel > 5).ToList();
        }
    }
}
