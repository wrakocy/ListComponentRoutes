using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Wrak.ListComponentRoutes
{
    public static class RouteAnalyzerMiddlewareExtensions
    {
        public static IServiceCollection AddListComponentRoutes(this IServiceCollection services, Action<RouteAnalyzerServiceConfig> configureOptions)
        {
            if (configureOptions == null) throw new ArgumentNullException(nameof(configureOptions));
            return services.Configure(configureOptions);
        }

        public static IApplicationBuilder UseListComponentRoutes(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RouteAnalyzerMiddleware>();
        }
    }
}
