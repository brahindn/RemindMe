namespace RemindMe.Contracts.Responses
{
    public class LogsResponse
    {
        public string Id { get; set; }
        public string UtcTimesTamp { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
    }
}
