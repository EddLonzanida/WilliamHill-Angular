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
        public async override Task<IHttpActionResult> GetItems(string search = "", int? page = 1, bool? desc = false, int? field = 0)
        {
            return await base.DoGetItemsAsync(search, page.Value, desc.Value, field.Value);
        }

        [Route("{id}")]
        [ResponseType(typeof(Customer))]
        [HttpGet]
        public async override Task<IHttpActionResult> Get(int id)
        {
            return await base.DoGetAsync(id);
        }

        [Route("Suggestions")]
        [HttpGet]
        public async override Task<IHttpActionResult> Suggestions(string search = "")
        {
            return await base.DoGetSuggestionsAsync(search);
        }

        [ResponseType(typeof(void))]
        [Route("{id}")]
        [HttpPut]
        public async override Task<IHttpActionResult> Put(int id, [FromBody] Customer item)
        {
            return await base.DoPutAsync(id, item);
        }

        [ResponseType(typeof(Customer))]
        [Route("")]
        [HttpPost]
        public async override Task<IHttpActionResult> Post([FromBody] Customer item)
        {
            return await base.DoPostAsync(item);
        }

        [ResponseType(typeof(Customer))]
        [Route("{id}")]
        [HttpDelete]
        public async override Task<IHttpActionResult> Delete(int id, string reason = "")
        {
            return await base.DoDeleteAsync(id, reason);
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

        protected override Func<IQueryable<Customer>, IQueryable<Customer>> GetOrderBy(int sortColumn, bool isdesc)
        {
            Func<IQueryable<Customer>, IQueryable<Customer>> orderBy = r => r.OrderBy(x => x.Name);

            if (isdesc) orderBy = r => r.OrderByDescending(x => x.Name);

            return orderBy;
        }

        protected override async Task<SearchResponse<Customer>> GetItemsAsync(string search, int page, bool desc, int sortColumn)
        {
            search = search.ToLower();
            Expression<Func<Customer, bool>> whereClause = r => search == "" || r.Name.ToLower().Contains(search);

            var orderBy = GetOrderBy(sortColumn, desc);
            var items = await repository.GetPagedListAsync(page, whereClause, orderBy);

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