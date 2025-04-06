using Microsoft.AspNetCore.Mvc;
using RemindMe.Application.IServices;
using RemindMe.Contracts.Requests;

namespace RemindMe.WebApi.Controllers
{
    [Route("api/reminders")]
    [ApiController]
    public class ReminderController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ReminderController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost("create-new-reminder")]
        public Task<IActionResult> CreateNewUser([FromBody] CreateReminderRequest reminder)
        {
            _serviceManager.ReminderService.CreateReminderAsync(reminder);

            return Task.FromResult<IActionResult>(Ok());
        }
    }
}
