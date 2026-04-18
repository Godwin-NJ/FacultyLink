using FacultyLinkApplication.Dto;
using FacultyLinkApplication.Interface;
using FacultyLinkApplication.Utility;
using FacultyLinkDomain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FacultyLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = Constant.Admin + "," + Constant.HeadOfUnit + "," + Constant.OfficeAdministrator)]
    public class UsersController : ControllerBase
    {
        private readonly IUser _userMd;
        public UsersController(IUser userMd) 
        { 
            _userMd = userMd;
        }

        /// <summary>
        /// Gets all users
        /// </summary>  
        /// <returns>/// </returns>
        [ProducesResponseType(typeof(List<User>), 200)]
        [HttpGet("getallusers")]
        public ActionResult GetAllUsers()
        {
            var getAllUsers = _userMd.GetAllUsers();
            return Ok(getAllUsers);
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         [ProducesResponseType(typeof(User), 200)]
        [HttpGet("getuserbyid")]
        public ActionResult GetUser(int id)
        {
            var getUser = _userMd.GetUser(id);
            return Ok(getUser);
        }

        /// <summary>
        /// Get user by email address
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(User), 200)]
        [HttpGet("getuserbyemailaddress")]
        public ActionResult GetUserByEmailAddress(string email)
        {
            var getUser = _userMd.GetUserByEmailAddress(email);
            return Ok(getUser);
        }

        /// <summary>
        /// Get users by date range
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<User>), 200)]
        [HttpGet("getusersbydaterange")]
        public ActionResult GetUsersByDate(DateTime startDate, DateTime endDate)
        {
            var getUser = _userMd.GetUsersByDate(startDate, endDate);
            return Ok(getUser);
        }

        /// <summary>
        /// Get users by year
        /// </summary>
        /// <param name="year"></param>       
        /// <returns></returns>
        [ProducesResponseType(typeof(List<User>), 200)]
        [HttpGet("getusersbyyear")]
        public ActionResult GetUsersByYear(string year)
        {
            var getUser = _userMd.GetUsersByYear(year);
            return Ok(getUser);
        }

        /// <summary>
        /// Get users by date range
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(User), 200)]
        [HttpPut("updateuser")]
        public ActionResult UpdateUser(int userId, User user)
        {
            var getUser = _userMd.UpdateUser(userId, user);
            return Ok(getUser);
        }

        /// <summary>
        /// Deactivate user
        /// </summary>      
        /// <param name="userId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ResponseMsg<object>), 200)]
        [HttpPost("deactivateuser")]
        public ActionResult DeactivateUser(int userId)
        {
            var getUser = _userMd.DeactivateUser(userId);
            return Ok(getUser);
        }
    }
}
