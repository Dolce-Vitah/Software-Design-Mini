using MoscowZooCleanArch.Application.DataTransferObjects;
using MoscowZooCleanArch.Application.Interfaces;
using MoscowZooCleanArch.Domain.Entities;
using MoscowZooCleanArch.Domain.Entities.ValueObjects;
using MoscowZooCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Application.Factories
{
    /// <summary>
    /// Factory class for creating animal objects.
    /// </summary>
    
    internal class AnimalFactory: IAnimalFactory
    {
        public IAnimal CreateAnimal(CreateAnimalDTO animalDto)
        {
            var _species = new Species(animalDto.Species);
            var _birthDate = new BirthDate(animalDto.DateOfBirth);
            var _gender = (Gender)animalDto.Gender;
            var _favFood = new Food(animalDto.FavoriteFood);
            var _status = (HealthStatus)animalDto.Status;

            return new Animal(animalDto.Name, _species, _birthDate, _gender, _favFood, _status);
        }
    }    
}
