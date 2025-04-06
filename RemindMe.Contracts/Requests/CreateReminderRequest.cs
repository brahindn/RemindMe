using System.Text.Json.Serialization;

namespace RemindMe.Contracts.Requests
{
    public record CreateReminderRequest
    {
        public string Message { get; set; }

        [JsonIgnore]
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public DateTime ShippingTime { get; set; }
        public Guid UserDestination { get; set; } = new Guid("0195fcb3-edff-7c3f-852e-4c4ffe37ce22");

    }
}
