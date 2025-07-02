using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemindMe.Contracts.Responses
{
    public record GetReminderResponse
    {
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public string? Message { get; set; }
        public DateTime ScheduledAt { get; set; }
        public string TargetType { get; set; }
        public string UserId { get; set; }
        public Guid UserDestination { get; set; }
    }
}
