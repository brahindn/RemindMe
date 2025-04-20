using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RemindMe.Application.IServices;
using RemindMe.Contracts.Requests;
using System.Net;

namespace RemindMe.WebApi.Controllers
{
    [Route("api/reminders")]
    [ApiController]
    public class ReminderController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly Serilog.ILogger _logger;

        public ReminderController(IServiceManager serviceManager, Serilog.ILogger logger)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }

        [HttpPost("create-new-reminder")]
        [ProducesResponseType(typeof(OkObjectResult), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateNewReminder([FromBody] CreateReminderRequest reminder)
        {
            await _serviceManager.ReminderService.CreateReminderAsync(reminder);

            _logger.Information($"The reminder created: {reminder.Message}");

            return Ok();
        }
    }
}
