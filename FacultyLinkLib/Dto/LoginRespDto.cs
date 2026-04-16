using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyLinkApplication.Dto
{
    public class LoginRespDto
    {
        public string Name { get; set; }
        public string Email { get; set; } // email will serve as username    
        public string Token { get; set; }
    }
}
