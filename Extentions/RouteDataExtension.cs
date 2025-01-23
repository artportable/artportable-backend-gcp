using Microsoft.AspNetCore.Routing;

namespace Artportable.API.Extentions
{
    public static class RouteDataExtension
    {
        public static string ToRouteName(this RouteData routeData)
        {
            string actionName = routeData.Values["action"].ToString();
            string controllerName = routeData.Values["controller"].ToString();
            return $"{controllerName}_{actionName}";
        }
    }
}
