using System.Text.Json.Serialization;

namespace RemindMe.Contracts.Requests
{
    public record CreateReminderRequest
    {
        public string Message { get; set; }

        [JsonIgnore]
        public DateTime CreationTime { get; set; }
        public DateTime ShippingTime { get; set; }
        public Guid UserDestination { get; set; }

    }
}
