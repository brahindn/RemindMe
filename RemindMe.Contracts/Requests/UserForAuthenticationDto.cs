using System.ComponentModel.DataAnnotations;

namespace RemindMe.Contracts.Requests
{
    public class UserForAuthenticationDto
    {
        [Required(ErrorMessage = "User name is requared")]
        public string? UserName { get; init; }

        [Required(ErrorMessage = "Password is requared")]
        public string? Password { get; init; }
    }
}
