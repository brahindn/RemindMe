using Microsoft.AspNetCore.Mvc;
using RemindMe.Application.IServices;
using RemindMe.Contracts.Requests;

namespace RemindMe.WebApi.Controllers
{
    [Route("api/reminders")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public UserController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
    }
}
