using System.Reflection;

namespace Wrak.ListComponentRoutes
{
    public class RouteAnalyzerServiceConfig
    {
        public string Path { get; set; } = "/routes";
        public Assembly[] Assemblies { get; set; }
    }
}
