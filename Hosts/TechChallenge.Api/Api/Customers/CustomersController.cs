using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Eml.Contracts.Controllers;
using Eml.ControllerBase;
using Eml.DataRepository.Contracts;
using Eml.Mediator.Contracts;
using TechChallenge.ApiHost.Dto;
using TechChallenge.Business.Common.Entities;
using TechChallenge.Business.Requests;
using TechChallenge.Business.Responses;

namespace TechChallenge.ApiHost.Api.Customers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/Customer")]
    public class CustomersController : CrudControllerApiBase<int, Customer, IndexRequest>
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
        public override async Task<IHttpActionResult> Index(int? page = 1, bool? desc = false, int? sortColumn = 0, string search = "")
        {
            var request = new IndexRequest(page, desc, sortColumn, search);
            var response = await DoIndexAsync(request);

            return Ok(response);
        }

        [Route("{id}")]
        [ResponseType(typeof(Customer))]
        [HttpGet]
        public override async Task<IHttpActionResult> Details(int id)
        {
            return await DoDetailsAsync(id);
        }

        [Route("Suggestions")]
        [HttpGet]
        public override async Task<IHttpActionResult> Suggestions(string search = "")
        {
            return await DoSuggestionsAsync(search);
        }

        [ResponseType(typeof(void))]
        [Route("{id}")]
        [HttpPut]
        public override async Task<IHttpActionResult> Put(int id, [FromBody]Customer item)
        {
            return await DoPutAsync(id, item);
        }

        [ResponseType(typeof(Customer))]
        [Route("")]
        [HttpPost]
        public override async Task<IHttpActionResult> Post([FromBody]Customer item)
        {
            return await DoPostAsync(item);
        }

        [ResponseType(typeof(Customer))]
        [Route("{id}")]
        [HttpDelete]
        public override async Task<IHttpActionResult> Delete(int id, string reason = "")
        {
            return await DoDeleteAsync(id, reason);
        }

        #endregion // SCAFFOLDINGS
        [Route("{Id}/Bets")]
        [HttpGet]
        [ResponseType(typeof(TotalBetCountResponse))]
        public async Task<IHttpActionResult> GetBets(int id, int pageNumber = 1)
        {
            var request = new TotalBetCountRequest(id, pageNumber);
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

        protected override async Task<ISearchResponse<Customer>> GetItemsAsync(IndexRequest request)
        {
            var search = request.Search.ToLower();
            Expression<Func<Customer, bool>> whereClause = r => search == "" || r.Name.ToLower().Contains(search);

            var orderBy = GetOrderBy(request.SortColumn, request.IsDescending);
            var items = await repository.GetPagedListAsync(request.Page, whereClause, orderBy);
            var response = new SearchResponse<Customer>(items, items.TotalItemCount, repository.PageSize);

            return response;
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