using FacultyLinkDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyLinkApplication.Interface
{
    public interface IUser
    {
        User GetUser (int id);
        User GetUserByEmailAddress (string email);
        List<User> GetAllUsers();
        //User CreateUser(User user); // under security
        //User UpdateUser(int id, User user); // under security
        //bool DeleteUser(int id); // under security

    }
}
