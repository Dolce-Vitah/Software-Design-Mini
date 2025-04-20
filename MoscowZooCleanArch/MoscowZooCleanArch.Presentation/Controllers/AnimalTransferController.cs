using Microsoft.AspNetCore.Mvc;
using MoscowZooCleanArch.Application.Interfaces;

namespace MoscowZooCleanArch.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalTransferController : ControllerBase
    {
        private readonly IAnimalTransferService _animalTransferService;

        public AnimalTransferController(IAnimalTransferService animalTransferService)
        {
            _animalTransferService = animalTransferService;
        }

        [HttpPost("transfer")]
        public IActionResult TransferAnimal([FromQuery] Guid animalId,
                                            [FromQuery] Guid from,
                                            [FromQuery] Guid to)
        {
            try
            {
                _animalTransferService.TransferAnimal(animalId, from, to);
                return Ok("Animal transferred successfully.");
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
