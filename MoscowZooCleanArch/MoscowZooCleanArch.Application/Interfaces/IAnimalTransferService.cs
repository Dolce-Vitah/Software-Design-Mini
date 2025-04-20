using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Application.Interfaces
{
    /// <summary>
    /// Interface for the Animal Transfer Service.
    /// </summary>
    
    public interface IAnimalTransferService
    {
        void TransferAnimal(Guid animalId, Guid from, Guid to);
    }
}
