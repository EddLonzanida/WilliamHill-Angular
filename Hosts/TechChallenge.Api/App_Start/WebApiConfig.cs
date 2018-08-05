﻿using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Newtonsoft.Json.Serialization;
using Swashbuckle.Application;
using TechChallenge.ApiHost.App_Start;

namespace TechChallenge.ApiHost
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Services.Add(typeof(IExceptionLogger), new GlobalExceptionLogger());

            // Web API configuration and services
            var formatters = config.Formatters;

            formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            formatters.Remove(config.Formatters.XmlFormatter);
            formatters.JsonFormatter.Indent = true;
            formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Swagger UI",
                routeTemplate: "",
                defaults: null,
                constraints: null,
                handler: new RedirectHandler(SwaggerDocsConfig.DefaultRootUrlResolver, "swagger/ui/index"));
        }
    }
}
