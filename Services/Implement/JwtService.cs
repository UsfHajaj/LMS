using LMS.Models.Auth;
using LMS.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LMS.Services.Implement
{
    public class JwtService:IJwtService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public JwtService(UserManager<AppUser> userManager,IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        private void ValidateUser(AppUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrEmpty(user.Id))
                throw new ArgumentNullException(nameof(user.Id), "User Id cannot be null or empty");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentNullException(nameof(user.UserName), "User Name cannot be null or empty");
            if (string.IsNullOrEmpty(user.Email))
                throw new ArgumentNullException(nameof(user.Email), "User Email cannot be null or empty");
        }
        private List<Claim> GetClaimsForUser(AppUser user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier,user.Id));
            claims.Add(new Claim(ClaimTypes.Name,user.UserName));
            claims.Add(new Claim(ClaimTypes.Email,user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()));

            var roles = _userManager.GetRolesAsync(user).Result;

            foreach(var i in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, i));
            }

            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["JWT:SecritKey"]));
            return new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        }

        private string CreateJwtToken(IEnumerable<Claim> claims, SigningCredentials signingCredentials)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration["JWT:IssuerIp"],
                audience: _configuration["JWT:AudienceIP"],
                claims: claims,
                expires:DateTime.UtcNow.AddDays(1),
                signingCredentials: signingCredentials
                );
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        public string GenerateJwtToken(AppUser user)
        {
            ValidateUser(user);
            var claims = GetClaimsForUser(user);
            var signingCredentials = GetSigningCredentials();
            var token = CreateJwtToken(claims, signingCredentials);
            return token;
        }
    }
}
