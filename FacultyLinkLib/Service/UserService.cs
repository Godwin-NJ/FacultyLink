using FacultyLinkApplication.Interface;
using FacultyLinkDomain;
using FacultyLinkDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacultyLinkApplication.Dto;
using FacultyLinkApplication.Utility;


namespace FacultyLinkApplication.Service
{
    public class UserService : IUser
    {
        private readonly AppDbContext _appDbContext;
        private readonly ISecurity _securityService;
        public UserService(AppDbContext appDbContext, ISecurity securityService) 
        {
            _appDbContext = appDbContext;
            _securityService = securityService;
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

        public List<User> GetUsersByDate(DateTime startDate, DateTime endDate)
        {
            var getUsers = _appDbContext.Users.Where(u => u.CreatedDate.Date >= startDate && u.CreatedDate.Date <= endDate).ToList();
            if (getUsers == null || getUsers.Count == 0)
            {
                throw new AppException("No users found in the specified date range");
            }
            return getUsers;
        }

        public List<User> GetUsersByYear(string year)
        {
            var getUsers = _appDbContext.Users.Where(u => u.CreatedDate.Year.ToString() == year).ToList();
            if (getUsers == null || getUsers.Count == 0)
            {
                throw new AppException("No users found for the specified year");
            }
            return getUsers;
        }

        public User UpdateUser(int userId, User user)
        {
            // this will have an approval leg
           var existingUser = _appDbContext.Users.SingleOrDefault(u => u.Id == userId);

            var getInitatorUserId = _securityService.GetClaimInfoFromToken(Constant.UserIdClaim);// get user id from token or http context

            if (existingUser == null)
            {
                throw new AppException("User not found");
            }
           
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.UpdatedBy = int.Parse(getInitatorUserId);// userId thats initiating request;
            _appDbContext.SaveChanges();
            return existingUser;
        }
        public ResponseMsg<object> DeactivateUser(int userId)
        {
            var existingUser = _appDbContext.Users.SingleOrDefault(u => u.Id == userId);
            if(existingUser == null)
            {
                throw new AppException("User not found");
            }
            existingUser.IsActive = false;
            _appDbContext.SaveChanges();
            return new ResponseMsg<object> { Message = "User deactivated successfully" };
        }

        public ResponseMsg<object> ApproveUserUpdate(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
