using Eml.Mef;
using Eml.MefDependencyResolver.Api;
using NLog;
using NLog.Common;
using System;
using System.IO;
using System.Web;
using System.Web.Http;
using Eml.Extensions;
using TechChallenge.Infrastructure;
using ErrorEventArgs = Newtonsoft.Json.Serialization.ErrorEventArgs;

namespace TechChallenge.Api
{
    public class WebApiApplication : HttpApplication
    {
        public static Eml.Logger.ILogger Logger { get; private set; }

        protected void Application_Start()
        {
            try
            {
                var today = DateTime.Today.ToString("yyyy-MM-dd");
                var binDirectory = TypeExtensions.GetBinDirectory();
                var nLogInternalFullPath = Path.Combine(binDirectory, "NLog", $"{today}-internal.log");

                InternalLogger.LogFile = nLogInternalFullPath;

                var config = GlobalConfiguration.Configuration;

                ConnectionStrings.SetOneTime();
                ApplicationSettings.SetOneTime();

                config.Formatters.JsonFormatter.SerializerSettings.Error = _serializationErrorHandler; //Handle EF6 circular navigation properties

                var classFactory = Bootstrapper.Init(binDirectory, new[] { "TechChallenge*.dll" });

                Logger = classFactory.GetExport<Eml.Logger.ILogger>();

                config.DependencyResolver = new MefDependencyResolver(classFactory.Container); // web api controllers

                GlobalConfiguration.Configure(WebApiConfig.Register);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                var logger = LogManager.GetCurrentClassLogger();

                logger.Fatal(e, "A fatal exception was thrown. The application cannot start.");

                throw;
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            const string MESSAGE = "An unhandled exception occurred";

            var exception = Server.GetLastError();

            if (exception == null) return;

            if (Logger == null)
            {
                var logger = LogManager.GetCurrentClassLogger();

                logger.Error(MESSAGE);
            }
            else Logger.Log.Error(exception, MESSAGE);
        }

        protected void Application_End()
        {
            const string MESSAGE = "Application stopping";

            if (Logger == null)
            {
                var logger = LogManager.GetCurrentClassLogger();

                logger.Info(MESSAGE);
            }
            else Logger.Log.Info(MESSAGE);
        }

        private readonly EventHandler<ErrorEventArgs> _serializationErrorHandler = (sender, args) =>
        {
            var isHandled = args.ErrorContext.Error.Message.Contains("on 'System.Data.Entity.DynamicProxies.");

            if (isHandled) args.ErrorContext.Handled = true;
        };
    }
}
