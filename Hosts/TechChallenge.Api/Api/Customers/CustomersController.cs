using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Eml.Mediator.Contracts;
using TechChallenge.ApiHost.Api.BaseClasses;
using TechChallenge.Business.Requests;
using TechChallenge.Business.Responses;

namespace TechChallenge.ApiHost.Api.Customers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("Customers")]
    public class CustomersController : ApiControllerBase
    {
        private readonly IMediator mediator;

        [ImportingConstructor]
        public CustomersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("")]
        [ResponseType(typeof(CustomerResponse))]
        public async Task<HttpResponseMessage> Get()
        {
            var request = new CustomerRequest();
            var response = await mediator.GetAsync(request);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("{Id}/Bets")]
        [HttpGet]
        [ResponseType(typeof(TotalBetCountResponse))]
        public async Task<HttpResponseMessage> Bets(int Id)
        {
            var request = new TotalBetCountRequest(Id);
            var response = await mediator.GetAsync(request);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


        [Route("Risks")]
        [HttpGet]
        [ResponseType(typeof(IList<RiskCustomerResponse>))]
        public async Task<HttpResponseMessage> Risks()
        {
            var request = new RiskCustomerRequest();
            var response = await mediator.GetAsync(request);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        protected override void RegisterIDisposable(List<IDisposable> disposables)
        {
        }
    }
}