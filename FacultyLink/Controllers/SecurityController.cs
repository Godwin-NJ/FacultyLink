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
    [Authorize(Roles = Constant.Admin + "," + Constant.HeadOfUnit)]
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

        /// <summary>
        /// User login
        ///</summary>
        [HttpPost("login")]
        [AllowAnonymous]
        public ActionResult<LoginRespDto> Login(LoginDto login)
        {
            var loginData = _security.Login(login);
            return loginData;
        }
    }
}
