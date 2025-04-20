using MoscowZooCleanArch.Domain.Entities;
using MoscowZooCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Application.Interfaces
{
    /// <summary>
    /// Interface for managing enclosures in the zoo.
    /// </summary>
    public interface IEnclosureRepository
    {
        void AddEnclosure(IEnclosure enclosure);

        void DeleteEnclosure(IEnclosure enclosure);

        IEnclosure? GetById(Guid id);

        IReadOnlyList<IEnclosure> GetAllEnclosures();
    }
}
