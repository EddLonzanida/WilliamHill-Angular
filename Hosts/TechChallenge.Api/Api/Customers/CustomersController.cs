using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Eml.ControllerBase;
using Eml.DataRepository.Contracts;
using Eml.Mediator.Contracts;
using TechChallenge.Business.Common.Entities;
using TechChallenge.Business.Requests;
using TechChallenge.Business.Responses;

namespace TechChallenge.ApiHost.Api.Customers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/Customer")]
    public class CustomersController : CrudControllerBase<int, Customer>
    {
        [ImportingConstructor]
        public CustomersController(IMediator mediator, IDataRepositorySoftDeleteInt<Customer> repository)
            : base(mediator, repository)
        {
        }

        #region SCAFFOLDINGS
        [Route("")]
        [ResponseType(typeof(SearchResponse<Customer>))]
        [HttpGet]
        public override async Task<IHttpActionResult> Get(string search = "", int? page = 1, bool? desc = false, int? field = 0)
        {
            return await base.Get(search, page, desc, field);
        }

        [Route("{id}")]
        [ResponseType(typeof(Customer))]
        [HttpGet]
        public override async Task<IHttpActionResult> Get(int id)
        {
            return await base.Get(id);
        }

        [Route("Suggestions")]
        [HttpGet]
        public override async Task<IHttpActionResult> Suggestions(string search = "")
        {
            return await base.Suggestions(search);
        }

        [ResponseType(typeof(void))]
        [Route("{id}")]
        public override async Task<IHttpActionResult> Put(int id, [FromBody] Customer item)
        {
            return await base.Put(id, item);
        }

        [ResponseType(typeof(Customer))]
        [Route("")]
        [HttpPost]
        public override Task<IHttpActionResult> Post([FromBody] Customer item)
        {
            return base.Post(item);
        }

        [ResponseType(typeof(Customer))]
        [Route("{id}")]
        [HttpDelete]
        public override async Task<IHttpActionResult> Delete(int id, string reason = "")
        {
            return await base.Delete(id, reason);
        }

        #endregion // SCAFFOLDINGS
        [Route("{Id}/Bets")]
        [HttpGet]
        [ResponseType(typeof(TotalBetCountResponse))]
        public async Task<IHttpActionResult> GetBets(int Id, int pageNumber = 1)
        {
            var request = new TotalBetCountRequest(Id, pageNumber);
            var response = await mediator.GetAsync(request);

            return Ok(response);
        }

        [Route("Risks")]
        [HttpGet]
        [ResponseType(typeof(IList<RiskCustomerResponse>))]
        public async Task<IHttpActionResult> GetRisks(int pageNumber = 1)
        {
            var request = new RiskCustomerRequest(pageNumber);
            var response = await mediator.GetAsync(request);

            return Ok(response);
        }

        protected override async Task<SearchResponse<Customer>> GetAll(string search = "", int? page = 1, bool? desc = false, int? sortColumn = 0)
        {
            search = search.ToLower();
            Expression<Func<Customer, bool>> whereClause = r => search == "" || r.Name.ToLower().Contains(search);

            Func<IQueryable<Customer>, IQueryable<Customer>> orderBy = r => r.OrderBy(x => x.Name);

            if (desc.Value) orderBy = r => r.OrderByDescending(x => x.Name);

            var items = await repository.GetPagedListAsync(page.Value, whereClause, orderBy);

            return new SearchResponse<Customer>(items, items.TotalItemCount, repository.PageSize);
        }

        protected override async Task<List<string>> GetSuggestionsAsync(string search = "")
        {
            return await repository
            .GetAutoCompleteIntellisenseAsync(r => search == "" || r.Name.ToLower().Contains(search),
                r => r.OrderBy(s => s.Name),
                r => r.Name);
        }

        protected override void RegisterIDisposable(List<IDisposable> disposables)
        {
        }
    }
}