using System.ComponentModel.DataAnnotations;

namespace RemindMe.Contracts.Requests
{
    public class UserForAuthenticationDto
    {
        public string? UserName { get; set; }

        public string? Password { get; set; }
    }
}
