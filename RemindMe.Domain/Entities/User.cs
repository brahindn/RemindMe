using System.ComponentModel.DataAnnotations;

namespace RemindMe.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; } 
        public ICollection<Reminder> Reminders { get; set; }
    }
}
