using MoscowZooCleanArch.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Domain.Interfaces
{
    /// <summary>
    /// Represents an enclosure in the zoo.
    /// </summary>
    public interface IEnclosure
    {
        Guid ID { get; }

        EnclosureType Type { get; }

        EnclosureSize Size { get; }

        int MaxCapacity { get; }

        int CurrentOccupancy { get; }

        bool IsClean { get; }

        void AddAnimal(IAnimal animal);

        void RemoveAnimal(IAnimal animal);
    }
}
