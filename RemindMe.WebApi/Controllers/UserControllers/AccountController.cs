using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using RemindMe.Contracts.Requests;
using RemindMe.Domain.Entities;
using RemindMe.Contracts.Responses;

namespace RemindMe.WebApi.Controllers.UserControllers
{
    [Route("/api/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly Serilog.ILogger _logger;

        public AccountController(UserManager<User> userManager, Serilog.ILogger logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest registerUserRequest)
        {
            if(registerUserRequest == null)
            {
                return BadRequest();
            }

            var user = registerUserRequest.Adapt<User>();
            var result = await _userManager.CreateAsync(user, registerUserRequest.Password);

            if(!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(new RegistrationResponsesDto { Errors = errors });
            }

            return StatusCode(201);
        }
    }
}
