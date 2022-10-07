using Microsoft.AspNetCore.Builder;
namespace Assginment5
{
    public static class MiddlewareExtentions
    {
        public static IApplicationBuilder UseLogginMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogginMiddleware>();
        }
    }
}