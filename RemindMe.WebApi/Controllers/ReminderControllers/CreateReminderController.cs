using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RemindMe.Application.IServices;
using RemindMe.Contracts.Requests;
using System.Net;
using System.Security.Claims;

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



        //[ProducesResponseType(typeof(OkObjectResult), (int)HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        [HttpPost("createNewReminder"), Authorize]
        public async Task<IActionResult> CreateNewReminder([FromBody] CreateReminderRequest newReminderRequest)
        { 
            if(newReminderRequest == null)
            {
                return BadRequest();
            }

            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

                if(userIdClaim == null)
                {
                    return Unauthorized();
                }

                newReminderRequest.UserId = userIdClaim.Value;

                await _serviceManager.ReminderService.CreateReminderAsync(newReminderRequest);

                _logger.Information("A reminder was created!");
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
