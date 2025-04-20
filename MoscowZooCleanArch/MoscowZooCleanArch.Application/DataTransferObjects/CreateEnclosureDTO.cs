using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Application.DataTransferObjects
{
    /// <summary>
    /// Data Transfer Object for creating an enclosure.s
    /// </summary>
    public class CreateEnclosureDTO
    {
        public string Type { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int Length { get; set; }

        public int MaxCapacity { get; set; }
    }
}
