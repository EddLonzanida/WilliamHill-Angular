using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace TechChallenge.Api
{
    public class GlobalExceptionLogger : ExceptionLogger
    {
        public override async Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
        {
            await Task.Run(() => WebApiApplication.Logger.Log.Error(context.Exception), cancellationToken);

            await base.LogAsync(context, cancellationToken);
        }
    }
}