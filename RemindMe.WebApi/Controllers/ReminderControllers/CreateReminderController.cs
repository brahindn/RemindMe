using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RemindMe.Application.IServices;
using RemindMe.Contracts.Requests;
using RemindMe.Contracts.Responses;
using RemindMe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RemindMe.WebApi.Controllers.ReminderControllers
{
    [Route("api/createReminder")]
    [ApiController]
    public class CreateReminderController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly Serilog.ILogger _logger;

        public CreateReminderController(IServiceManager serviceManager, Serilog.ILogger logger  )
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }

        [HttpPost("create-new-reminder")]
        [Authorize]
        [ProducesResponseType(typeof(OkObjectResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateNewReminder()
        {
            var newReminderRequest = new CreateReminderRequest()
            {
                UserId = new Guid("9a585e08-9397-47cc-b429-963cb865ece0"),
                Title = "Test reminder 20.06.2025",
                Message = "Test reminder message",
                CreatedAt = DateTime.Now,
                ScheduledAt = new DateTime(2025, 6, 30),
                UserDestination = new Guid("9a585e08-9397-47cc-b429-963cb865ece0")
            };

            try
            {
                await _serviceManager.ReminderService.CreateReminderAsync(newReminderRequest);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error during creating of reminder");
                return BadRequest();
            }

            return Ok();
        }
    }
}
