using Microsoft.AspNetCore.Mvc;
using MoscowZooCleanArch.Application.DataTransferObjects;
using MoscowZooCleanArch.Application.Interfaces;
using MoscowZooCleanArch.Infrastructure.Repositories;

namespace MoscowZooCleanArch.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedingScheduleController: ControllerBase
    {
        private readonly IFeedingScheduleRepository _feedingScheduleRepository;
        private readonly IFeedingScheduleFactory _feedingScheduleFactory;
        private readonly IAnimalRepository _animalRepository;

        public FeedingScheduleController(IFeedingScheduleRepository feedingScheduleRepository, IFeedingScheduleFactory feedingScheduleFactory, 
                                         IAnimalRepository animalRepository)
        {
            _feedingScheduleRepository = feedingScheduleRepository;
            _feedingScheduleFactory = feedingScheduleFactory;
            _animalRepository = animalRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetFeedingScheduleById(Guid id)
        {
            var feedingSchedule = _feedingScheduleRepository.GetById(id);
            if (feedingSchedule == null)
            {
                return NotFound();
            }
            return Ok(feedingSchedule);
        }

        [HttpPost]
        public IActionResult CreateFeedingSchedule([FromBody] CreateFeedingScheduleDTO feedingScheduleDto, 
                                                   [FromQuery] Guid animalId)
        {
            if (feedingScheduleDto == null)
            {
                return BadRequest();
            }

            var animal = _animalRepository.GetById(animalId);

            if (animal == null)
            {
                return NotFound($"Animal with ID {animalId} not found.");
            }

            try
            {
                var feedingSchedule = _feedingScheduleFactory.CreateFeedingSchedule(feedingScheduleDto, animal);
                _feedingScheduleRepository.AddFeedingSchedule(feedingSchedule);

                return CreatedAtAction(nameof(GetFeedingScheduleById), new { id = feedingSchedule.ID }, feedingSchedule);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFeedingSchedule(Guid id)
        {
            var feedingSchedule = _feedingScheduleRepository.GetById(id);
            if (feedingSchedule == null)
            {
                return NotFound();
            }

            try
            {
                _feedingScheduleRepository.DeleteFeedingSchedule(feedingSchedule);
                return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
