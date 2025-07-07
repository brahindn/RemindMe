
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
