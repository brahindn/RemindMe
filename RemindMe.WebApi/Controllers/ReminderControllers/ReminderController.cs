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
    [Authorize]
    public class ReminderController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly Serilog.ILogger _logger;

        public ReminderController(IServiceManager serviceManager, Serilog.ILogger logger  )
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }

        [ProducesResponseType(typeof(OkObjectResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        [HttpPost("createNewReminder")]
        public async Task<IActionResult> CreateNewReminder([FromBody] CreateReminderRequest newReminderRequest)
        { 
            if(newReminderRequest == null)
            {
                return BadRequest();
            }

            try
            {
                GetUserIdFromClaims();

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

        [HttpGet("getReminderById")]
        public async Task<IActionResult> GetReminder([FromQuery] Guid Id)
        {
            var reminder = await _serviceManager.ReminderService.GetReminderAsync(Id);

            _logger.Information("A reminder was got");

            return Ok(reminder);
        }

        [HttpDelete("deleteReminder")]
        public async Task<IActionResult> DeleteReminder([FromQuery] Guid Id)
        {
            await _serviceManager.ReminderService.DeleteReminderAsync(Id);

            _logger.Information("A reminder was deleted!");

            return NoContent();
        }

        [HttpPut("updateReminder")]
        public async Task<IActionResult> UpdateReminder([FromBody] UpdateReminderRequest updateReminderRequest)
        {
            if(updateReminderRequest == null)
            {
                return BadRequest();
            }

            try
            {
                await _serviceManager.ReminderService.UpdateReminderAsync(updateReminderRequest);

                _logger.Information("The reminder was updated!");
            }
            catch(Exception ex)
            {
                _logger.Error(ex, "Something went wrong during an reminder updating!");

                return BadRequest();
            }

            return Ok();
        }

        private string GetUserIdFromClaims()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            return userIdClaim?.Value ?? throw new UnauthorizedAccessException("User Id claim not found");
        }
    }
}
