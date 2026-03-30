using FacultyLinkApplication.Dto;
using FacultyLinkApplication.Interface;
using FacultyLinkDomain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FacultyLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurity _security;

        public SecurityController(ISecurity security)
        {
            _security = security;
        }

        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("createuser")]       
        public ActionResult<ResponseMsg<User>> CreateUser(UserDto dto)
        {
            var userData = _security.CreateUser(dto);
            return userData;
        }
    }
}
