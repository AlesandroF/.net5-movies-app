using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Helper
{
    public static class ControllerHelper
    {
        const string routeAttributeName = "RouteAttribute";

        public static string GetRoute<T>(string methodName)
            where T : ControllerBase
        {
            var routeController = (typeof(T).CustomAttributes.FirstOrDefault(c => c.AttributeType.Name == routeAttributeName)?
                .ConstructorArguments[0].Value?.ToString() ?? string.Empty) + "/";
            var method = typeof(T).GetMethod(methodName);
            if (method is not null)
            {
                var route = method.CustomAttributes.FirstOrDefault(c => c.AttributeType.Name == routeAttributeName) ??
                            method.CustomAttributes.FirstOrDefault(c => c.AttributeType.Name.Contains("Http"));
                if (route?.ConstructorArguments.Any() ?? false)
                    return routeController + route?.ConstructorArguments[0].Value;
            }

            return routeController;
        }
    }
}