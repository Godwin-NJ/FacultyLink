using FacultyLinkApplication.Interface;
using FacultyLinkDomain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FacultyLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
    }
}
