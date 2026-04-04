using FacultyLinkApplication.Dto;
using FacultyLinkDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyLinkApplication.Interface
{
    public interface ISecurity
    {
        ResponseMsg<User> CreateUser(UserDto user);
        LoginRespDto Login(LoginDto login);
        string HashPassword(string password);
        bool VerifyHashPassword(string password, string hashedPassword);
    }
}
