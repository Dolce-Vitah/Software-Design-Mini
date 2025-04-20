using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MoscowZooCleanArch.Application.Interfaces;

namespace MoscowZooCleanArch.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsStatisticsServiceController : ControllerBase
    {
        private readonly IAnimalsStatisticsService animalsStatisticsService;

        public AnimalsStatisticsServiceController(IAnimalsStatisticsService animalsStatisticsService)
        {
            this.animalsStatisticsService = animalsStatisticsService;
        }

        [HttpGet("total")]
        public IActionResult GetTotalAnimalsCount()
        {
            var totalAnimals = animalsStatisticsService.GetTotalAnimalsCount();
            return Ok(new { TotalAnimals = totalAnimals });
        }

        [HttpGet("sick")]
        public IActionResult GetSickAnimalsCount()
        {
            var sickAnimals = animalsStatisticsService.GetSickAnimalsCount();
            return Ok(new { SickAnimals = sickAnimals });
        }

        [HttpGet("female")]
        public IActionResult GetFemaleAnimalsCount()
        {
            var femaleAnimals = animalsStatisticsService.GetFemaleAnimalsCount();
            return Ok(new { FemaleAnimals = femaleAnimals });
        }

        [HttpGet("male")]
        public IActionResult GetMaleAnimalsCount()
        {
            var maleAnimals = animalsStatisticsService.GetMaleAnimalsCount();
            return Ok(new { MaleAnimals = maleAnimals });
        }
    }
}
