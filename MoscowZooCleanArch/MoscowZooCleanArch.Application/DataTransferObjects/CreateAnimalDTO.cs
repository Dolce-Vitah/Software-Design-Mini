using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Application.DataTransferObjects
{
    /// <summary>
    /// Data Transfer Object for creating a new animal.
    /// </summary>
    public class CreateAnimalDTO
    {
        public string Name { get; set; }

        public string Species { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string FavoriteFood { get; set; }

        public bool Status { get; set; }

    }
}
