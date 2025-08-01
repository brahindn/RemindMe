﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RemindMe.Contracts.Requests
{
    public record CreateReminderRequest
    {
        public string Title { get; set; } = string.Empty;
        public string? Message { get; set; } = string.Empty;
        public DateTime ScheduledAt { get; set; }
        public string TargetType { get; set; } = "email";
        public string UserId { get; set; }
        public Guid UserDestination { get; set; }
    }
}
 