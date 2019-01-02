using Eml.ControllerBase;
using Eml.Mediator.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TechChallenge.Business.Common.Requests;
using TechChallenge.Business.Common.Responses;

namespace TechChallenge.ApiHost.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("Amounts")]
    public class AmountsController : ControllerApiBase
    {
        [ImportingConstructor]
        public AmountsController(IMediator mediator)
            : base(mediator)
        {
        }

        [Route("")]
        [HttpGet]
        [ResponseType(typeof(TotalBetAmountResponse))]
        public async Task<IHttpActionResult> Index()
        {
            var request = new TotalBetAmountAsyncRequest();
            var response = await mediator.GetAsync(request);

            return Ok(response);
        }

        [HttpGet]
        [ResponseType(typeof(double))]
        [Route("Total")]
        public async Task<IHttpActionResult> GetTotal()
        {
            var request = new TotalBetAmountAsyncRequest();
            var response = await mediator.GetAsync(request);
            var grandTotal = response.CustomerBets.Sum(r => r.Totalstake);

            return Ok(grandTotal);
        }

        protected override void RegisterIDisposable(List<IDisposable> disposables)
        {
        }
    }
}
