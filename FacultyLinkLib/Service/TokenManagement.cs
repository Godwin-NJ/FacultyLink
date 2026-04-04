using FacultyLinkApplication.Dto;
using FacultyLinkApplication.Interface;
using FacultyLinkDomain.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FacultyLinkApplication.Service
{
    public class TokenManagement : ITokenManagement
    {
        private readonly IConfiguration _config;
        private readonly TokenManagementDto _tokenConfig;
        public TokenManagement(IConfiguration config)
        {
            _config = config;
            _tokenConfig = _config.Get<TokenManagementDto>();
        }
        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.Email),
                new Claim(ClaimTypes.Surname,user.LastName),
                new Claim("userid",user.Id.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfig.SecretKey));

            var cred = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var securityTokenPaylod = new JwtSecurityToken(
                audience: _tokenConfig.Audience,
                issuer: _tokenConfig.Issuer,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_tokenConfig.TokenDuration),
                signingCredentials: cred
            );

            var token = new JwtSecurityTokenHandler().WriteToken(securityTokenPaylod);
            return token;

        }
    }
}
