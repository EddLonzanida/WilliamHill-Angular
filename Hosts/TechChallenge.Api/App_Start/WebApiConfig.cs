using System.Web.Http;
using Newtonsoft.Json.Serialization;
using Swashbuckle.Application;

namespace TechChallenge.ApiHost
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var formatters = config.Formatters;
            formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            formatters.Remove(config.Formatters.XmlFormatter);
            formatters.JsonFormatter.Indent = true;
            formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.MapHttpAttributeRoutes();

            // Redirect root to Swagger UI
            config.Routes.MapHttpRoute(
                name: "Swagger UI",
                routeTemplate: "",
                defaults: null,
                constraints: null,
                handler: new RedirectHandler(SwaggerDocsConfig.DefaultRootUrlResolver, "swagger/ui/index"));
        }
    }
}
