using FacultyLinkDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyLinkApplication.Interface
{
    public interface ITokenManagement
    {
        string GenerateToken(User user);

        //verify token 
        // Get user information from token 
    }
}
