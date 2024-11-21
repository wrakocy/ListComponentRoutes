using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Wrak.ListComponentRoutes.Tests.WebApp;

namespace Wrak.ListComponentRoutes.Tests.Functional
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        public string Path { get; set; }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.Configure<RouteAnalyzerServiceConfig>(config =>
                {
                    config.Assemblies = new[] { typeof(Startup).Assembly };

                    if (!string.IsNullOrEmpty(Path))
                        config.Path = Path;
                });
            });
        }
    }
}