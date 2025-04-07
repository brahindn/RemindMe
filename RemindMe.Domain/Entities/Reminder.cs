using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RemindMe.Domain.Entities
{
    public class Reminder
    {
        [Key]
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime CreationTime { get; set; } //Unavailable property for User
        public DateTime ShippingTime { get; set; }
        public Guid UserDestination { get; set; }

        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
