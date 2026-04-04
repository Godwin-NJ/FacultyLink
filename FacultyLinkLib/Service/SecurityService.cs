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
      
        public SecurityService(AppDbContext appDbContext, ILogger<SecurityService> log) 
        {
            _appContext = appDbContext;
            _log = log;           
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

            var hashPwd = HashPassword(login.Password);
            var verifyPwd = VerifyHashPassword(userExist.Password, hashPwd);

            if(!verifyPwd)
            {
                _log.LogInformation($"User : {login.Email} invalid password");
                throw new AppException("Invalid username or password");
            }


            var dt = new LoginDto
            {

            };

            return new LoginRespDto();
        }

        public string HashPassword(string passowrd)
        {
            var passwordHasher = new PasswordHasher<object>();
            var result = passwordHasher.HashPassword(null!, passowrd);
            return result;

        }

        public bool VerifyHashPassword(string password, string hashedPassword)
        {
            var passwordHasher = new PasswordHasher<object>();
            PasswordVerificationResult result = passwordHasher.VerifyHashedPassword(null!, hashedPassword, password);
            return result == PasswordVerificationResult.Success ? true : false;
        }
    }
}
