using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Application.Interfaces
{
    /// <summary>
    /// Interface for statistics related to enclosures in the zoo.
    /// </summary>
    
    public interface IEnclosureStatisticsService
    {
        int GetTotalEnclosuresCount();

        int GetEmptyEnclosuresCount();

        int GetPredatorEnclosuresCount();

        int GetHerbivoreEnclosuresCount();

        int GetBirdEnclosuresCount();

        int GetAquaticEnclosuresCount();

        int GetCleanEnclosuresCount();
    }
}
