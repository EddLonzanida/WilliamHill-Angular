using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using TechChallenge.Api;

[assembly: OwinStartup(typeof(Startup))]
namespace TechChallenge.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //app.MapSignalR();
        }

        private static void ConfigureAuth(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
        }
    }
}