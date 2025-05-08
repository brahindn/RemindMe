using RemindMe.Contracts.Requests;

namespace RemindMe.Application.IServices
{
    public interface IAuthenticationService
    {
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<string> CreateToken();
    }
}
