using FacultyLinkApplication.Dto;
using FacultyLinkApplication.Interface;
using FacultyLinkApplication.Utility;
using FacultyLinkDomain;
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
        private readonly AppDbContext _context;
        public TokenManagement(IConfiguration config, AppDbContext context)
        {
            _config = config;
            _tokenConfig = _config.GetSection("TokenManagement").Get<TokenManagementDto>() ?? new TokenManagementDto();
            _context = context;
        }
        public string GenerateToken(User user)
        {
            var role = _context.UserGroup.Where(x => x.GroupId == user.GroupId)?.Select(g => g.Name)
                        .FirstOrDefault() ?? string.Empty;

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.Email),
                new Claim(ClaimTypes.Surname,user.LastName),
                new Claim(Constant.UserIdClaim,user.Id.ToString()),
                new Claim(ClaimTypes.Role, role),
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
