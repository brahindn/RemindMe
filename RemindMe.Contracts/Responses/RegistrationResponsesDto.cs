namespace RemindMe.Contracts.Responses
{
    public class RegistrationResponsesDto
    {
        public bool IsSuccessfulRegistration { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
