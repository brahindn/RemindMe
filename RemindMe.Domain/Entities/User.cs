using Microsoft.AspNetCore.Identity;

namespace RemindMe.Domain.Entities
{
    public class User : IdentityUser
    {
        public ICollection<Reminder> Reminders { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
