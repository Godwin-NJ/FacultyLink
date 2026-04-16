using FacultyLinkApplication.Dto;
using FacultyLinkApplication.Interface;
using FacultyLinkDomain;
using FacultyLinkDomain.Model;
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

        public SecurityService(AppDbContext appDbContext, ILogger<SecurityService> log, ITokenManagement tokenManagement)
        {
            _appContext = appDbContext;
            _log = log;
            _tokenManagement = tokenManagement;
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
                Token = _tokenManagement.GenerateToken(userExist)
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
    }
}
