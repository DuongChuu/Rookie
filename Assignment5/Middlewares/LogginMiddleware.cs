using Microsoft.AspNetCore.Http;
using System.Diagnostics;
namespace Assginment5
{
    public class LogginMiddleware
    {
        private readonly RequestDelegate _next;
        public LogginMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;
            string requestInformation = "scheme:" + request.Scheme +
            "\nHost" + request.Host +
            "\nPath" + request.QueryString +
            "\nRequestBody" + request.Body;

            Debug.Write(requestInformation);
            File.WriteAllText("textInformation.txt", requestInformation);

            await _next(context);
        }
    }
}