using MoscowZooCleanArch.Application.DataTransferObjects;
using MoscowZooCleanArch.Application.Factories;
using MoscowZooCleanArch.Application.Interfaces;
using MoscowZooCleanArch.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Test.FactoryTests
{
    public class AnimalFactoryTest
    {
        [Fact]
        public void CreateAnimal_ShouldReturnAnimalWithCorrectProperties()
        {
            // Arrange
            var animalDto = new CreateAnimalDTO
            {
                Name = "Leo",
                Species = "Lion",
                DateOfBirth = DateTime.Now.AddYears(-5),
                Gender = "Male",
                FavoriteFood = "Meat",
                Status = true // Healthy
            };

            var factory = new AnimalFactory();

            // Act
            var animal = factory.CreateAnimal(animalDto);

            // Assert
            Assert.NotNull(animal);
            Assert.Equal(animalDto.Name, animal.Name);
            Assert.Equal(animalDto.Species, animal.Species.Type);
            Assert.Equal(animalDto.DateOfBirth, animal.DateOfBirth.Value);
            Assert.Equal(Gender.Male, animal.Gender);
            Assert.Equal(animalDto.FavoriteFood, animal.FavoriteFood.Name);
            Assert.Equal(HealthStatus.Healthy, animal.Status);
        }

        [Fact]
        public void CreateAnimal_ShouldThrowArgumentExceptionForInvalidGender()
        {
            // Arrange
            var animalDto = new CreateAnimalDTO
            {
                Name = "Leo",
                Species = "Lion",
                DateOfBirth = DateTime.UtcNow.AddYears(-5),
                Gender = "InvalidGender",
                FavoriteFood = "Meat",
                Status = true
            };

            var factory = new AnimalFactory();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateAnimal(animalDto));
        }

        [Fact]
        public void CreateAnimal_ShouldThrowArgumentExceptionForFutureBirthDate()
        {
            // Arrange
            var animalDto = new CreateAnimalDTO
            {
                Name = "Leo",
                Species = "Lion",
                DateOfBirth = DateTime.UtcNow.AddDays(1), // Future date
                Gender = "Male",
                FavoriteFood = "Meat",
                Status = true
            };

            var factory = new AnimalFactory();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateAnimal(animalDto));
        }

        [Fact]
        public void CreateAnimal_ShouldThrowArgumentExceptionForEmptySpecies()
        {
            // Arrange
            var animalDto = new CreateAnimalDTO
            {
                Name = "Leo",
                Species = "", // Empty species
                DateOfBirth = DateTime.UtcNow.AddYears(-5),
                Gender = "Male",
                FavoriteFood = "Meat",
                Status = true
            };

            var factory = new AnimalFactory();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateAnimal(animalDto));
        }
    }
}
