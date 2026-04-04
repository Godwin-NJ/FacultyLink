using FacultyLinkApplication.Interface;
using FacultyLinkDomain;
using FacultyLinkDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacultyLinkApplication.Dto;


namespace FacultyLinkApplication.Service
{
    public class UserService : IUser
    {
        private readonly AppDbContext _appDbContext;
        public UserService(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;

        }
        public List<User> GetAllUsers()
        {
            var getAllUsers = _appDbContext.Users.ToList();
            if (getAllUsers == null || getAllUsers.Count == 0)
            {
                throw new AppException("No user found");
            }
            return getAllUsers;
        }

        public User GetUser(int id)
        {
           var getUser = _appDbContext.Users.SingleOrDefault(u => u.Id == id);

            if (getUser == null)
            {
                throw new AppException("User not found");
            }
            return getUser;
        }

        public User GetUserByEmailAddress(string email)
        {
            var getUser = _appDbContext.Users.SingleOrDefault(u => u.Email == email);

            if (getUser == null)
            {
                throw new AppException("User not found");
            }
            return getUser;
        }
    }
}
