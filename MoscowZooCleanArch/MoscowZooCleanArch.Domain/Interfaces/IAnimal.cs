using MoscowZooCleanArch.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Domain.Interfaces
{
    /// <summary>
    /// Represents an animal in the zoo.
    /// </summary>
    public interface IAnimal
    {
        Guid ID { get; }

        string Name { get; }

        Species Species { get; }

        BirthDate DateOfBirth { get; }

        Gender Gender { get; }

        Food FavoriteFood { get; }

        HealthStatus Status { get; }

        void MoveToEnclosure(IEnclosure from, IEnclosure to);
    }
}
