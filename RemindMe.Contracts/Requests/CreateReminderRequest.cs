using System.ComponentModel.DataAnnotations.Schema;

namespace RemindMe.Contracts.Requests
{
    public record CreateReminderRequest
    {
        public string Message { get; set; } = string.Empty;
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public DateTime ShippingTime { get; set; }
        public Guid UserDestination { get; set; }

    }
}
