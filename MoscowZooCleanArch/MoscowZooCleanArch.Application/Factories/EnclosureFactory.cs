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
    /// Factory class for creating enclosure objects.
    /// </summary>
    
    internal class EnclosureFactory: IEnclosureFactory
    {
        public IEnclosure CreateEnclosure(CreateEnclosureDTO enclosureDto)
        {
            var _enclosureType = (EnclosureType)enclosureDto.Type;
            var _size = new EnclosureSize(enclosureDto.Width, enclosureDto.Height, enclosureDto.Length);
            var _maxCapacity = enclosureDto.MaxCapacity;

            return new Enclosure(_enclosureType, _size, _maxCapacity);
        }        
    }
}
