
namespace RemindMe.Contracts.Responses
{
    public record GetReminderResponse
    (
        Guid Id,
        string Title,
        string? Message,
        DateTime ScheduledAt,
        string TargetType,
        string UserId,
        Guid UserDestination
    );
}
