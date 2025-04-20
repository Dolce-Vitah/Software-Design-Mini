using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Application.Interfaces
{
    /// <summary>
    /// Interface for managing adding/removing animal from enclosures in the zoo.
    /// </summary>
    public interface IEnclosureManagementService
    {
        void AddAnimalToEnclosure(Guid animalId, Guid enclosureId);

        void RemoveAnimalFromEnclosure(Guid animalId, Guid enclosureId);
    }
}
