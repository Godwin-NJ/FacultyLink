using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyLinkApplication.Dto
{
    public class ResponseMsg<T>
    {
        public string Message { get; set; } = "Success"; // Default message
        public T? Data { get; set; }
        public int StatusCode { get; set; } = 200; // Default to 200 (OK)
    }
}
