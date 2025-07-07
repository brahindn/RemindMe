using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemindMe.Contracts.Requests
{
    public record UpdateReminderRequest
    (
        Guid Id,
        string Title,
        string Message,
        DateTime ScheduledAt,
        string TargetType,
        string UserId,
        Guid UserDestination
    );
}
