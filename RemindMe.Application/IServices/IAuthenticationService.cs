using RemindMe.Contracts.AccessToken;
using RemindMe.Contracts.Requests;

namespace RemindMe.Application.IServices
{
    public interface IAuthenticationService
    {
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<TokenDto> CreateToken(bool populateExp);
    }
}
