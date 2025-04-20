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
    /// Interface for the Enclosure Factory.
    /// </summary>
    public interface IEnclosureFactory
    {
        IEnclosure CreateEnclosure(CreateEnclosureDTO enclosureDto);
    }
}
