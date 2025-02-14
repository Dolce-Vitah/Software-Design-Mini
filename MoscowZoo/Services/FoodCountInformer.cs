using MoscowZooAccounting.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Services
{
    /// <summary>
    /// The class is responsible for informing about the animals' daily food consumption 
    /// </summary>
    
    public class FoodCountInformer: IInfoProvider
    {
        private IZoo Zoo {  get; set; }

        public FoodCountInformer(IZoo zoo) => Zoo = zoo;

        public string GetInfo()
        {
            int totalFoodPerDay = CountFoodPerDay();

            return $"The total amount of food required per day: {totalFoodPerDay}";
        }

        public int CountFoodPerDay()
        {
            return Zoo.GetAnimals.Sum(animal => animal.Food);
        }
    }
}
