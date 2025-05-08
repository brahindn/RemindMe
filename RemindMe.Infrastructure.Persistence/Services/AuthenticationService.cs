using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using RemindMe.Application.IRepositories;
using RemindMe.Application.IServices;
using RemindMe.Contracts.Requests;
using RemindMe.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;

namespace RemindMe.Infrastructure.Persistence.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly Serilog.ILogger _logger;

        private User? _user;

        public AuthenticationService(IRepositoryManager repositoryManager, UserManager<User> userManager, IConfiguration configuration, Serilog.ILogger logger)
        {
            _repositoryManager = repositoryManager;
            _userManager = userManager;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
        {
            _user = await _userManager.FindByNameAsync(userForAuth.UserName);

            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuth.Password));

            if(!result)
            {
                _logger.Warning($"{nameof(ValidateUser)}: Authentication failed. Wrong user name or password.");
            }

            return result;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials(); 
            var claims = await GetClaims(); 
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims); 
            
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return jwtSecurityTokenHandler;
        }

        private SigningCredentials GetSigningCredentials() 
        {
            using var hmac = new HMACSHA256();
            var hmacKey = hmac.Key;
            var key = Convert.ToBase64String(hmacKey);
            var secret = new SymmetricSecurityKey(Convert.FromBase64String(key)); 
            var signingCredentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

            return signingCredentials;
        }

        private async Task<List<Claim>> GetClaims()
        {

            var claims = new List<Claim> 
            {
                new Claim(ClaimTypes.Name, _user.UserName) 
            };
            
            var roles = await _userManager.GetRolesAsync(_user);
            
            foreach (var role in roles) 
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            
            return claims; 
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var tokenOptions = new JwtSecurityToken
            (
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                signingCredentials: signingCredentials
            );

            return tokenOptions;
        }
    }
}
