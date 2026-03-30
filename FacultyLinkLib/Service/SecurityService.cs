using FacultyLinkApplication.Dto;
using FacultyLinkApplication.Interface;
using FacultyLinkDomain;
using FacultyLinkDomain.Model;
using Microsoft.AspNetCore.Identity;
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
        public SecurityService(AppDbContext appDbContext) 
        {
            _appContext = appDbContext;
        }
        public ResponseMsg<User> CreateUser(UserDto user)
        {
            var userExist = _appContext.Users.FirstOrDefault(u => u.Email == user.Email);
            if (userExist != null)
            {
                throw new Exception("User with this email already exists.");
            }

            var hashPassword = HashPassword(user.Password, new User { Email = user.Email });

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
            throw new NotImplementedException();
        }

        public string HashPassword(string passowrd, User user)
        {
            var passwordHasher = new PasswordHasher<User>();
            var result = passwordHasher.HashPassword(user, passowrd);
            return result;

        }

        public bool VerifyHashPassword(string password, string hashedPassword, User user)
        {
            var passwordHasher = new PasswordHasher<User>();
            PasswordVerificationResult result = passwordHasher.VerifyHashedPassword(user, hashedPassword, password);
            return result == PasswordVerificationResult.Success ? true : false;
        }
    }
}
