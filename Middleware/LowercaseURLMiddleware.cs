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
            // Only handle GET requests for lowercase enforcement
            if (context.Request.Method == HttpMethods.Get)
            {
                var path = context.Request.Path.Value;

                // Convert URL to lowercase and add trailing slash if necessary
                if (!path.Equals(path.ToLowerInvariant()) || !path.EndsWith("/"))
                {
                    path = path.ToLowerInvariant().TrimEnd('/') + "/";
                    context.Response.Redirect(path + context.Request.QueryString, true);
                    return;
                }
            }

            await _next(context);
        }
    }
}
