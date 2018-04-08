﻿using System;
using System.Web.Http;
using Eml.Mef;
using Eml.MefDependencyResolver.Api;
using Newtonsoft.Json.Serialization;
using NLog;
using NLog.Config;

namespace TechChallenge.ApiHost
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static Eml.Logger.ILogger Logger { get; private set; }


        protected void Application_Start()
        {
            //use ApplicationInsights
            ConfigurationItemFactory.Default.Targets.RegisterDefinition(
                "ApplicationInsightsTarget",
                typeof(Microsoft.ApplicationInsights.NLogTarget.ApplicationInsightsTarget)
            );

            var logger = LogManager.GetCurrentClassLogger();
            logger.Info("Application starting");

            try
            {
                var config = GlobalConfiguration.Configuration;
                config.Formatters.JsonFormatter.SerializerSettings.Error = _serializationErrorHandler; //Handle EF6 circular navigation properties

                var rootFolder = System.Web.Hosting.HostingEnvironment.MapPath(@"~\bin");
                var classFactory = Bootstrapper.Init(rootFolder, new[] { "TechChallenge*.dll" });

                Logger = classFactory.GetExport<Eml.Logger.ILogger>();

                config.DependencyResolver = new MefDependencyResolver(classFactory.Container); // web api controllers
                GlobalConfiguration.Configure(WebApiConfig.Register);

                logger.Info("Application started");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                logger.Fatal(e, "A fatal exception was thrown. The application cannot start.");
                throw;
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            const string msg = "An unhandled exception occurred";
            var exception = Server.GetLastError();

            if (exception == null) return;

            if (Logger == null)
            {
                var logger = LogManager.GetCurrentClassLogger();
                logger.Info(msg);
            }
            else Logger.Log.Error(exception, msg);
        }

        protected void Application_End()
        {
            const string msg = "Application stopping";

            if (Logger == null)
            {
                var logger = LogManager.GetCurrentClassLogger();
                logger.Info(msg);
            }
            else Logger.Log.Info(msg);
        }

        private readonly EventHandler<ErrorEventArgs> _serializationErrorHandler = (sender, args) =>
        {
            var isHandled = args.ErrorContext.Error.Message.Contains("on 'System.Data.Entity.DynamicProxies.");

            if (isHandled) args.ErrorContext.Handled = true;
        };
    }
}
