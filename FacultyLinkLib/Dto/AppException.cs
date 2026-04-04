

namespace FacultyLinkApplication.Dto
{
    public class AppException: Exception
    {
        public int StatusCode { get; } // Default to 400 Bad Request

        public AppException(string message, int statusCode = 400) : base(message)
        {
            StatusCode = statusCode;
        }

        // Static helpers so you don't have to remember status codes
        //public static AppException NotFound(string message) => new AppException(404, message);
        //public static AppException BadRequest(string message) => new AppException(400, message);
        //public static AppException Forbidden(string message) => new AppException(403, message);
    }
}
