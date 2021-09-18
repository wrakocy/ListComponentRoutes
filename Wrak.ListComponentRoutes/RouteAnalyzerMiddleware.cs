using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Text;
using System.Threading.Tasks;

namespace Wrak.ListComponentRoutes
{
    public class RouteAnalyzerMiddleware
    {
        private readonly RouteAnalyzerServiceConfig _config;
        private readonly RequestDelegate _next;

        public RouteAnalyzerMiddleware(RequestDelegate next, IOptions<RouteAnalyzerServiceConfig> config)
        {
            _config = config.Value;
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path == _config.Path)
            {
                var routeDescriptors = RouteAnalyzer.Analyze();
                var sb = new StringBuilder();

                sb.Append("<h1>Component Routes</h1>");
                sb.Append("<table style='width:100%;'><thead>");
                sb.Append("<tr align='left'><th>Route</th><th>Component Name</th><th>Component Namespace</th></tr>");
                sb.Append("</thead><tbody>");

                foreach (var rd in routeDescriptors)
                {
                    sb.Append("<tr align='left'>");
                    sb.Append($"<td style='width:40%;'>{rd.Route}</td>");
                    sb.Append($"<td style='width:20%;'>{rd.ComponentName}</td>");
                    sb.Append($"<td style='width:40%;'>{rd.ComponentNamespace}</td>");                              
                    sb.Append("</tr>");
                }

                sb.Append("</tbody></table>");
                await httpContext.Response.WriteAsync(sb.ToString());
            }
            else
            {
                await _next(httpContext);
            }
        }
    }
}
