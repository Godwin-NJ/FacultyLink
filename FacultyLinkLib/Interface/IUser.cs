using FacultyLinkApplication.Dto;
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
        List<User> GetUsersByDate(DateTime startDate, DateTime endDate);
        List<User> GetUsersByYear(string year);       
        User UpdateUser(int userId, User user); // under security
        ResponseMsg<object> ApproveUserUpdate(int userId); // under security
        ResponseMsg<object> DeactivateUser(int userId); // under security

    }
}
