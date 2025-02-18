using LumelApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LumelApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly IStatsService _statsService;

        public StatsController(IStatsService statsService)
        {
            _statsService = statsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTotalNoOfOrdersWithinDate(DateTime fromDate, DateTime toDate)
        {
            var result = await _statsService.GetTotalNoOfOrdersWithinDate(fromDate, toDate);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetTotalNoOfCustomersWithinDate(DateTime fromDate, DateTime toDate)
        {
            var result = await _statsService.GetTotalNoOfCustomersWithinDate(fromDate, toDate);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAvgOrderValueWithinDate(DateTime fromDate, DateTime toDate)
        {
            var result = await _statsService.GetAvgOrderValueWithinDate(fromDate, toDate);
            return Ok(result);
        }
    }
}
