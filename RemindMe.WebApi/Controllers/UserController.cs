using Microsoft.AspNetCore.Mvc;
using RemindMe.Application.IServices;
using RemindMe.Contracts.Requests;

namespace RemindMe.WebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public UserController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost("create-new-user")]
        public Task<IActionResult> CreateNewUser([FromBody] CreateUserRequest user)
        {
            _serviceManager.UserService.CreateUserAsync(user);

            return Task.FromResult<IActionResult>(Ok());
        }
    }
}
