using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using RemindMe.Contracts.Requests;
using RemindMe.Domain.Entities;
using RemindMe.Contracts.Responses;
using RemindMe.Application.IServices;

namespace RemindMe.WebApi.Controllers.UserControllers
{
    [Route("/api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly UserManager<User> _userManager;
        private readonly Serilog.ILogger _logger;

        public AuthenticationController(IServiceManager serviceManager, UserManager<User> userManager, Serilog.ILogger logger)
        {
            _serviceManager = serviceManager;
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

            _logger.Information($"New user {user.UserName} was registred.");

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto userForAuthenticationDto)
        {
            if (!await _serviceManager.AuthenticationService.ValidateUser(userForAuthenticationDto))
            {
                return Unauthorized();
            }

            var tokenDto = await _serviceManager.AuthenticationService.CreateToken(populateExp: true);

            return Ok(tokenDto);
        }
    }
}
