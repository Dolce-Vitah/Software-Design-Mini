using Microsoft.AspNetCore.Mvc;
using MoscowZooCleanArch.Application.Interfaces;

namespace MoscowZooCleanArch.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnclosureManagementServiceController: ControllerBase
    {
        private readonly IEnclosureManagementService _enclosureManagementService;
        public EnclosureManagementServiceController(IEnclosureManagementService enclosureManagementService)
        {
            _enclosureManagementService = enclosureManagementService;
        }

        /// <summary>
        /// Add an animal to an enclosure.
        /// </summary>
        /// <param name="animalId"></param>
        /// <param name="enclosureId"></param>
        /// <returns></returns>
        
        [HttpPost("add")]
        public IActionResult AddAnimalToEnclosure(Guid animalId, Guid enclosureId)
        {
            try
            {
                _enclosureManagementService.AddAnimalToEnclosure(animalId, enclosureId);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        /// <summary>
        /// Remove an animal from an enclosure.
        /// </summary>
        /// <param name="animalId"></param>
        /// <param name="enclosureId"></param>
        /// <returns></returns>
        
        [HttpPost("remove")]
        public IActionResult RemoveAnimalFromEnclosure(Guid animalId, Guid enclosureId)
        {
            try
            {
                _enclosureManagementService.RemoveAnimalFromEnclosure(animalId, enclosureId);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}
