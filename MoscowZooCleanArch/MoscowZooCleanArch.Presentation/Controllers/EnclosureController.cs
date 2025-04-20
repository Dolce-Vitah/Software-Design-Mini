using Microsoft.AspNetCore.Mvc;
using MoscowZooCleanArch.Application.DataTransferObjects;
using MoscowZooCleanArch.Application.Interfaces;

namespace MoscowZooCleanArch.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnclosureController: ControllerBase
    {
        private readonly IEnclosureRepository _enclosureRepository;
        private readonly IEnclosureFactory _enclosureFactory;

        public EnclosureController(IEnclosureRepository enclosureRepository, IEnclosureFactory enclosureFactory)
        {
            _enclosureRepository = enclosureRepository;
            _enclosureFactory = enclosureFactory;
        }

        /// <summary>
        /// Get an enclosure by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public IActionResult GetEnclosureById(Guid id)
        {
            var enclosure = _enclosureRepository.GetById(id);
            if (enclosure == null)
            {
                return NotFound();
            }
            return Ok(enclosure);
        }

        /// <summary>
        /// Create a new enclosure.
        /// </summary>
        /// <param name="enclosureDto"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult CreateEnclosure([FromBody] CreateEnclosureDTO enclosureDto)
        {
            if (enclosureDto == null)
            {
                return BadRequest();
            }

            try
            {
                var enclosure = _enclosureFactory.CreateEnclosure(enclosureDto);
                _enclosureRepository.AddEnclosure(enclosure);

                return CreatedAtAction(nameof(GetEnclosureById), new { id = enclosure.ID }, enclosure);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete an enclosure by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public IActionResult DeleteEnclosure(Guid id)
        {
            var enclosure = _enclosureRepository.GetById(id);
            if (enclosure == null)
            {
                return NotFound();
            }

            try
            {
                _enclosureRepository.DeleteEnclosure(enclosure);
                return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
