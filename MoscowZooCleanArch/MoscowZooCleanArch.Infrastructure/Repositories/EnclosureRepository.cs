using MoscowZooCleanArch.Application.Interfaces;
using MoscowZooCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Infrastructure.Repositories
{
    /// <summary>
    /// This class provides methods to manage enclosures in the zoo.
    /// </summary>
    public class EnclosureRepository : IEnclosureRepository
    {
        private List<IEnclosure> _enclosures = new List<IEnclosure>();

        public void AddEnclosure(IEnclosure enclosure)
        {
            if (enclosure == null)
            {
                throw new ArgumentNullException("Enclosure cannot be null.", nameof(enclosure));
            }
            if (!_enclosures.Contains(enclosure))
            {
                _enclosures.Add(enclosure);
            }
        }

        public void DeleteEnclosure(IEnclosure enclosure)
        {
            if (enclosure == null)
            {
                throw new ArgumentNullException("Enclosure cannot be null.", nameof(enclosure));
            }
            if (_enclosures.Contains(enclosure))
            {
                _enclosures.Remove(enclosure);
            }
        }

        public IEnclosure? GetById(Guid id)
        {
            return _enclosures.FirstOrDefault(e => e.ID == id);
        }

        public IReadOnlyList<IEnclosure> GetAllEnclosures()
        {
            return _enclosures.AsReadOnly();
        }
    }
}
