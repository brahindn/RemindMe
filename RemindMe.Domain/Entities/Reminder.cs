using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RemindMe.Domain.Entities
{
    public class Reminder
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string? Message { get; set; }
        public DateTime ScheduledAt { get; set; }
        public bool IsSent { get; set; } = false;
        public string TargetType { get; set; } = "email";
        public DateTime CreatedAt { get; set; } //Unavailable property for User
        public DateTime? UpdatedAt { get; set; }
        public DateTime? SentAt { get; set; }
        public Guid UserDestination { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
