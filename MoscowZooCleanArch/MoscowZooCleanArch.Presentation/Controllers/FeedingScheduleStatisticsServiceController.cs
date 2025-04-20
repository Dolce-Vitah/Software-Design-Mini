using Microsoft.AspNetCore.Mvc;
using MoscowZooCleanArch.Application.Interfaces;

namespace MoscowZooCleanArch.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedingScheduleStatisticsServiceController: ControllerBase
    {
        private readonly IFeedingScheduleStatisticsService feedingScheduleStatisticsService;
        public FeedingScheduleStatisticsServiceController(IFeedingScheduleStatisticsService feedingScheduleStatisticsService)
        {
            this.feedingScheduleStatisticsService = feedingScheduleStatisticsService;
        }

        [HttpGet("upcoming")]
        public IActionResult GetUpcomingFeedingSchedulesCount()
        {
            var upcomingSchedules = feedingScheduleStatisticsService.GetUpcomingFeedingSchedules();
            return Ok(upcomingSchedules.Select(fs => new
            {
                fs.ID,
                FeedingTime = fs.FeedingTime.Time,
                fs.IsCompleted
            }));
        }

        [HttpGet("missed")]
        public IActionResult GetFedAnimalsCount()
        {
            var missedSchedules = feedingScheduleStatisticsService.GetMissedFeedingSchedules();
            return Ok(missedSchedules.Select(fs => new
            {
                fs.ID,
                FeedingTime = fs.FeedingTime.Time,
                fs.IsCompleted
            }));
        }
    }    
}
