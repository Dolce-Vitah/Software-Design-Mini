using Microsoft.AspNetCore.Mvc;
using MoscowZooCleanArch.Application.DataTransferObjects;
using MoscowZooCleanArch.Application.Interfaces;

namespace MoscowZooCleanArch.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController: ControllerBase
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IAnimalFactory _animalFactory;

        public AnimalsController(IAnimalRepository animalRepository, IAnimalFactory animalFactory)
        {
            _animalRepository = animalRepository;
            _animalFactory = animalFactory;
        }

        /// <summary>
        /// Get an animal by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var animal = _animalRepository.GetById(id);
            if (animal == null)
            {
                return NotFound();
            }
            return Ok(animal);
        }

        /// <summary>
        /// Create a new animal.
        /// </summary>
        /// <param name="animalDto"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Create([FromBody] CreateAnimalDTO animalDto)
        {
            if (animalDto == null)
            {
                return BadRequest();
            }

            try
            {
                var animal = _animalFactory.CreateAnimal(animalDto);
                _animalRepository.AddAnimal(animal);

                return CreatedAtAction(nameof(GetById), new { id = animal.ID }, animal);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete an existing animal.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var animal = _animalRepository.GetById(id);
            if (animal == null)
            {
                return NotFound();
            }

            try
            {
                _animalRepository.DeleteAnimal(animal);
                return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
