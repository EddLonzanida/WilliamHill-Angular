using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Eml.ControllerBase;
using Eml.Mediator.Contracts;
using TechChallenge.Business.Requests;
using TechChallenge.Business.Responses;

namespace TechChallenge.ApiHost.Api.Dashboard
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("Dashboard")]
    public class DashboardController : ControllerApiBase
    {
        [ImportingConstructor]
        public DashboardController(IMediator mediator)
            : base(mediator)
        {
        }

        [Route("")]
        [HttpGet]
        [ResponseType(typeof(RaceStatResponse))]
        public async Task<IHttpActionResult> Index(int? pageNumber = 1)
        {
            var request = new RaceStatRequest(pageNumber.Value);
            var response = await mediator.GetAsync(request);

            return Ok(response);
        }

        protected override void RegisterIDisposable(List<IDisposable> disposables)
        {
        }
    }
}