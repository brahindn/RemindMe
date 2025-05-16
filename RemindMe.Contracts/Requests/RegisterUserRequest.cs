using System.ComponentModel.DataAnnotations;

namespace RemindMe.Contracts.Requests
{
    public record RegisterUserRequest
    {
        [Required]
        [StringLength(8, ErrorMessage = "Name length can't be more than 8.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(30, ErrorMessage = "Password must be at least 10 characters long.", MinimumLength = 10)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
