using MoscowZooCleanArch.Domain.Entities.ValueObjects;
using MoscowZooCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Domain.Entities
{
    /// <summary>  
    /// Represents a feeding schedule for an animal in the zoo.  
    /// </summary>  
    public class FeedingSchedule : IFeedingSchedule
    {
        public Guid ID { get; private set; } = Guid.NewGuid();

        public IAnimal Animal { get; private set; }

        public FeedingTime FeedingTime { get; private set; }

        public Food FoodType { get; private set; }

        public bool IsCompleted { get; private set; } = false;

        public FeedingSchedule(IAnimal animal, FeedingTime feedingTime, Food foodType)
        {
            Animal = animal ?? throw new ArgumentNullException("Animal cannot be null.", nameof(animal));
            FeedingTime = feedingTime ?? throw new ArgumentNullException("Feeding time cannot be null.", nameof(feedingTime));
            FoodType = foodType ?? throw new ArgumentNullException("Food type cannot be null.", nameof(foodType));
        }

        /// <summary>  
        /// Changes the feeding schedule time for the animal.  
        /// </summary>  
        /// <param name="newFeedingTime"></param>  
        /// <param name="newFoodType"></param>  
        /// <exception cref="ArgumentNullException"></exception>  

        public void ChangeFeedingTime(FeedingTime newFeedingTime)
        {
            if (newFeedingTime == null)
            {
                throw new ArgumentNullException("New feeding time cannot be null.", nameof(newFeedingTime));
            }            
            FeedingTime = newFeedingTime;
            IsCompleted = false; // Reset completion status when schedule is changed  
        }

        /// <summary>
        /// Changes the food type for the animal.
        /// </summary>
        /// <param name="newFoodType"></param>
        /// <exception cref="ArgumentNullException"></exception>

        public void ChangeFoodType(Food newFoodType)
        {
            if (newFoodType == null)
            {
                throw new ArgumentNullException("New food type cannot be null.", nameof(newFoodType));
            }
            FoodType = newFoodType;
        }

        /// <summary>  
        /// Marks the feeding schedule as completed.  
        /// </summary>  

        public void MarkAsCompleted()
        {
            IsCompleted = true;
        }

        public override string ToString()
        {
            return $"Feeding Schedule (ID: {ID}): {Animal.Name} will be fed {FoodType} at {FeedingTime.Time}. Completed: {IsCompleted}";
        }
    }
}
