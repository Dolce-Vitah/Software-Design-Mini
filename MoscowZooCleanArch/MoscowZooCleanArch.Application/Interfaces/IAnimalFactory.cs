using MoscowZooCleanArch.Application.DataTransferObjects;
using MoscowZooCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Application.Interfaces
{
    /// <summary>
    /// Factory interface for creating animals.
    /// </summary>
    public interface IAnimalFactory
    {
        IAnimal CreateAnimal(CreateAnimalDTO animalDto);
    }
}
