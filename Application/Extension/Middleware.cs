using Microsoft.AspNetCore.Http;

namespace Application.Extension
{
    public class Middleware
    {
        private readonly RequestDelegate _next;
        public Middleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {

                await _next(context);
            }
            finally
            {
            }
        }
    }
}
