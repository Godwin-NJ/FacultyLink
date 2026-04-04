using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyLinkApplication.Dto
{
    public class TokenManagementDto
    {
        public string SecretKey { get; set; }
        public int TokenDuration { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
