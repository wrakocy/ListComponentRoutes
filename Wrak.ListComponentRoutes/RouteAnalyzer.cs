using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Wrak.ListComponentRoutes
{
    internal class RouteAnalyzer
    {
        public static List<RouteDescriptor> Analyze(Assembly[] assemblies)
        {
            if (assemblies == null) throw new ArgumentNullException(nameof(assemblies));

            var components = assemblies
                .SelectMany(assembly => assembly
                .ExportedTypes
                .Where(t => t.IsSubclassOf(typeof(ComponentBase))));

            var routes = components
                .Select(component => GetRouteDescriptorFromComponent(component))
                .Where(descriptor => descriptor is not null)
                .OrderBy(x => x.Route)
                .ToList();

            return routes;
        }

        private static RouteDescriptor GetRouteDescriptorFromComponent(Type component)
        {
            var attributes = component.GetCustomAttributes(inherit: true);
            var routeAttribute = attributes.OfType<RouteAttribute>().FirstOrDefault();

            if (!String.IsNullOrEmpty(routeAttribute?.Template))
            {
                return new RouteDescriptor
                {
                    ComponentNamespace = component.Namespace,
                    ComponentName = component.Name,
                    Route = routeAttribute.Template
                };
            }

            return null;
        }
    }
}
