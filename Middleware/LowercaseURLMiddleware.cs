namespace Assignment_2.Middleware
{
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public class LowercaseURLMiddleware
    {
        private readonly RequestDelegate _next;

        public LowercaseURLMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Convert URL to lowercase
            var path = context.Request.Path.Value.ToLowerInvariant();

            // Check if the path ends with a slash
            if (!path.EndsWith("/"))
            {
                path += "/";
                context.Response.Redirect(path, true);
                return;
            }

            // Set the new path
            context.Request.Path = path;

            await _next(context);
        }
    }
}
