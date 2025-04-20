using Microsoft.AspNetCore.Mvc;
using MoscowZooCleanArch.Application.Interfaces;

namespace MoscowZooCleanArch.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedingOrganizationServiceController: ControllerBase
    {
        private readonly IFeedingOrganizationService feedingOrganizationService;

        public FeedingOrganizationServiceController(IFeedingOrganizationService feedingOrganizationService)
        {
            this.feedingOrganizationService = feedingOrganizationService;
        }

        [HttpPost("feed")]
        public IActionResult FeedAnimal([FromQuery] Guid feedingScheduleId)
        {
            try
            {
                feedingOrganizationService.FeedAnimal(feedingScheduleId);
                return Ok("An animal has been fed successfully.");
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

        [HttpPost("changeTime")]
        public IActionResult ChangeFeedingTime([FromQuery] Guid feedingScheduleId,
                                               [FromQuery] DateTime newTime)
        {
            try
            {
                feedingOrganizationService.ChangeFeedingTime(feedingScheduleId, newTime);
                return Ok("The feeding time has been changed successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("changeFood")]
        public IActionResult ChangeFoodType([FromQuery] Guid feedingScheduleId,
                                            [FromQuery] string newFoodType)
        {
            try
            {
                feedingOrganizationService.ChangeFoodType(feedingScheduleId, newFoodType);
                return Ok("The food type has been changed successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
