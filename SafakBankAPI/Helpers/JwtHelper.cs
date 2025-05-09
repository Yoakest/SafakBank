
using Microsoft.IdentityModel.Tokens;
using SafakBankApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace SafakBankAPI.Helpers
{
    public class JwtHelper
    {
        private readonly string _secretKey;
        private readonly int _expirationMinutes;

        public JwtHelper(IConfiguration configuration)
        {
            _secretKey = configuration["JwtSettings:SecretKey"];
            _expirationMinutes = int.Parse(configuration["JwtSettings:ExpirationMinutes"]);
        }
        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Surname, user.Surname),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("UserCode", user.UserCode)
                }),
                Expires = DateTime.UtcNow.AddMinutes(_expirationMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
