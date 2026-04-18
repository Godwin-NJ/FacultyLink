using FacultyLinkApplication.Dto;
using FacultyLinkApplication.Interface;
using FacultyLinkDomain;
using FacultyLinkDomain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FacultyLinkApplication.Service
{
    public class SecurityService : ISecurity
    {
        private readonly AppDbContext _appContext;
        private readonly ILogger<SecurityService> _log;
        private readonly ITokenManagement _tokenManagement;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SecurityService(AppDbContext appDbContext, ILogger<SecurityService> log, 
            ITokenManagement tokenManagement,
            IHttpContextAccessor httpContextAccessor)
        {
            _appContext = appDbContext;
            _log = log;
            _tokenManagement = tokenManagement;
            _httpContextAccessor = httpContextAccessor;
        }
        public ResponseMsg<User> CreateUser(UserDto user)
        {
            var userExist = _appContext.Users.FirstOrDefault(u => u.Email == user.Email);
            if (userExist != null)
            {
                _log.LogInformation($"User : {user.Email} already exist");
                throw new AppException("User with this email already exists.");
            }

            var hashPassword = HashPassword(user.Password);

            _appContext.Users.Add(new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = hashPassword,               
              
            });

            _appContext.SaveChanges();
            
            var getUser = _appContext.Users.FirstOrDefault(u => u.Email == user.Email);

            return new ResponseMsg<User>
            {
                Message = "User created successfully",
                Data = getUser
            };
        }

        public LoginRespDto Login(LoginDto login)
        {
            var userExist = _appContext.Users.SingleOrDefault(x => x.Email == login.Email);           

            if (userExist == null)
            {
                _log.LogInformation($"User : {login.Email} does not exist");
                throw new AppException("Invalid username or password");
            }

            var userRole = _appContext.UserGroup.Where(x => x.GroupId == userExist.GroupId)?.Select(g => g.Name)
                       .FirstOrDefault() ?? string.Empty;


            var verifyPwd = VerifyHashPassword(userExist, userExist.Password, login.Password);

            if(!verifyPwd)
            {
                _log.LogInformation($"User : {login.Email} invalid password");
                throw new AppException("Invalid username or password");
            }


            var dt = new LoginRespDto
            {
                Name = $"{userExist.FirstName} {userExist.LastName}",
                Email = userExist.Email,
                Token = _tokenManagement.GenerateToken(userExist),
                Role = userRole,
                RoleId = userExist.GroupId ?? 0
            };

            return dt;
        }

        public string HashPassword(string passowrd)
        {
            var passwordHasher = new PasswordHasher<object>();
            var result = passwordHasher.HashPassword(null!, passowrd);
            return result;

        }

        public bool VerifyHashPassword(User user, string hashedPassword, string password)
        {
            var passwordHasher = new PasswordHasher<User>();
            PasswordVerificationResult result = passwordHasher.VerifyHashedPassword(user, hashedPassword, password);
            return result == PasswordVerificationResult.Success ? true : false;
        }

        public string GetClaimInfoFromToken(string targetClaim)
        {
            var claimValue = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == targetClaim)?.Value;
            return claimValue ?? string.Empty;
        }

        public string GetUsersToken()
        {
            //var token = await HttpContext.GetTokenAsync("access_token");// ASPDOTNET default method of getting the raw token
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            return token ?? string.Empty;
        }
    }
}
