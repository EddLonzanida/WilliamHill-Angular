using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Eml.Mediator.Contracts;
using TechChallenge.ApiHost.Api.BaseClasses;
using TechChallenge.Business.Requests;
using TechChallenge.Business.Responses;

namespace TechChallenge.ApiHost.Api.Amounts
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("Amounts")]
    public class AmountsController : ApiControllerBase
    {
        private readonly IMediator mediator;

        [ImportingConstructor]
        public AmountsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("")]
        [ResponseType(typeof(TotalBetAmountResponse))]
        public async Task<HttpResponseMessage> Get()
        {
            var request = new TotalBetAmountRequest();
            var response = await mediator.GetAsync(request);

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [ResponseType(typeof(double))]
        [Route("Total")]
        public async Task<HttpResponseMessage> GetTotal()
        {
            var request = new TotalBetAmountRequest();
            var response = await mediator.GetAsync(request);
            var grandTotal = response.CustomerBets.Sum(r => r.Totalstake);

            return Request.CreateResponse(HttpStatusCode.OK, grandTotal);
        }

        protected override void RegisterIDisposable(List<IDisposable> disposables)
        {
        }
    }
}
