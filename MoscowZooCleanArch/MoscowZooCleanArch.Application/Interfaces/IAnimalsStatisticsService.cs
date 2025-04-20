using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Application.Interfaces
{
    /// <summary>
    /// Interface for the Animals Statistics Service.
    /// </summary>
    public interface IAnimalsStatisticsService
    {
        int GetTotalAnimalsCount();

        int GetSickAnimalsCount();

        int GetFemaleAnimalsCount();

        int GetMaleAnimalsCount();
    }
}
