using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RemindMe.Domain.Entities
{
    public class Reminder
    {
        [Key]
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime CreationTime { get; } = DateTime.Now;
        public DateTime ShippingTime { get; set; }
        public Guid UserDestination { get; set; }

        [ForeignKey("UserId")]
        public Guid UserId { get; set; } = new Guid("0195fcb3-191a-7051-8d9b-88d23c189f8b");
        public User User { get; set; }
    }
}
