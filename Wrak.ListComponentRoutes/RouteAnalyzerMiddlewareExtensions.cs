using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Wrak.ListComponentRoutes
{
    public static class RouteAnalyzerMiddlewareExtensions
    {
        public static IServiceCollection AddListComponentRoutes(this IServiceCollection services,  string listRoutesPath = "/routes")
        {
            if (string.IsNullOrEmpty(listRoutesPath)) throw new NullReferenceException($"{listRoutesPath} routes path cannot be null.");
            return services.AddListComponentRoutes(x => x.Path = listRoutesPath);
        }

        public static IServiceCollection AddListComponentRoutes(this IServiceCollection services, Action<RouteAnalyzerServiceConfig> configureOptions)
        {
            if (configureOptions == null) throw new NullReferenceException($"{nameof(configureOptions)} cannot be null.");
            return services.Configure(configureOptions);
        }

        public static IApplicationBuilder UseListComponentRoutes(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RouteAnalyzerMiddleware>();
        }
    }
}
