using Microsoft.AspNetCore.Mvc;
using MoscowZooCleanArch.Application.Interfaces;

namespace MoscowZooCleanArch.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnclosureStatisticsServiceController: ControllerBase
    {
        private readonly IEnclosureStatisticsService enclosureStatisticsService;
        public EnclosureStatisticsServiceController(IEnclosureStatisticsService enclosureStatisticsService)
        {
            this.enclosureStatisticsService = enclosureStatisticsService;
        }

        [HttpGet("total")]
        public IActionResult GetTotalEnclosuresCount()
        {
            var totalEnclosures = enclosureStatisticsService.GetTotalEnclosuresCount();
            return Ok(new { TotalEnclosures = totalEnclosures });
        }

        [HttpGet("empty")]
        public IActionResult GetEmptyEnclosuresCount()
        {
            var emptyEnclosures = enclosureStatisticsService.GetEmptyEnclosuresCount();
            return Ok(new { EmptyEnclosures = emptyEnclosures });
        }

        [HttpGet("predator")]
        public IActionResult GetPredatorEnclosuresCount()
        {
            var predatorEnclosures = enclosureStatisticsService.GetPredatorEnclosuresCount();
            return Ok(new { PredatorEnclosures = predatorEnclosures });
        }

        [HttpGet("herbivore")]
        public IActionResult GetHerbivoreEnclosuresCount()
        {
            var herbivoreEnclosures = enclosureStatisticsService.GetHerbivoreEnclosuresCount();
            return Ok(new { HerbivoreEnclosures = herbivoreEnclosures });
        }

        [HttpGet("bird")]
        public IActionResult GetBirdEnclosuresCount()
        {
            var birdEnclosures = enclosureStatisticsService.GetBirdEnclosuresCount();
            return Ok(new { BirdEnclosures = birdEnclosures });
        }

        [HttpGet("aquatic")]
        public IActionResult GetAquaticEnclosuresCount()
        {
            var aquaticEnclosures = enclosureStatisticsService.GetAquaticEnclosuresCount();
            return Ok(new { AquaticEnclosures = aquaticEnclosures });
        }

        [HttpGet("clean")]
        public IActionResult GetCleanEnclosuresCount()
        {
            var cleanEnclosures = enclosureStatisticsService.GetCleanEnclosuresCount();
            return Ok(new { CleanEnclosures = cleanEnclosures });
        }
    }
}
