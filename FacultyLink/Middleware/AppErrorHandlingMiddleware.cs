using FacultyLinkApplication.Dto;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FacultyLink.Middleware
{
    public class AppErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public AppErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;   
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AppException ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = ex.StatusCode;

                var errorResponse = new { message = ex.Message };
                await context.Response.WriteAsJsonAsync(errorResponse);
            }         
        }
    }
}
