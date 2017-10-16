using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Example.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            RouteTable.Routes.MapRoute(
                "WithActionApi",
                "api/{controller}/{action}/{id}"
            );


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
