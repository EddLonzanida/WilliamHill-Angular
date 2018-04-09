﻿using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace TechChallenge.ApiHost.App_Start
{
    public class GlobalExceptionLogger : ExceptionLogger
    {
        public override async Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
        {
            await Task.Run(() => WebApiApplication.Logger.Log.Error(context.Exception));

            await base.LogAsync(context, cancellationToken);
        }
    }
}