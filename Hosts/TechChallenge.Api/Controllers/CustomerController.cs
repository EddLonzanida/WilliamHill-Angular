using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Eml.Contracts.Response;
using Eml.ControllerBase;
using Eml.DataRepository.Contracts;
using Eml.Mediator.Contracts;
using TechChallenge.Business.Common.Entities;
using TechChallenge.Business.Common.Requests;
using TechChallenge.Business.Common.Responses;

namespace TechChallenge.Api.Controllers
{
    [RoutePrefix("api/Customer")]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CustomerController : CrudControllerApiBase<int, Customer, IndexRequest>
    {
        [ImportingConstructor]
        public CustomerController(IMediator mediator, IDataRepositorySoftDeleteInt<Customer> repository)
            : base(mediator, repository)
        {
        }

        [Route("")]
        [HttpGet]
        [ResponseType(typeof(SearchResponse<Customer>))]
        public override async Task<IHttpActionResult> Index(int? page = 1, bool? desc = false, int? sortColumn = 0, string search = "")
        {
            var request = new IndexRequest(page, desc, sortColumn, search);
            var response = await DoIndexAsync(request);

            return Ok(response);
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(Customer))]
        public override async Task<IHttpActionResult> Details(int id)
        {
            return await DoDetailsAsync(id);
        }

        [Route("{id}")]
        [HttpPut]
        public override async Task<IHttpActionResult> Edit(int id, [FromBody]Customer item)
        {
            return await DoEditAsync(id, item);
        }

        [HttpPost]
        [ResponseType(typeof(Customer))]
        public override async Task<IHttpActionResult> Create([FromBody]Customer item)
        {
            return await DoCreateAsync(item);
        }

        [Route("{id}")]
        [HttpDelete]
        public override async Task<IHttpActionResult> Delete(int id, string reason = "")
        {
            return await DoDeleteAsync(id, reason);
        }

        [HttpGet]
        [ResponseType(typeof(string[]))]
        public override async Task<IHttpActionResult> Suggestions(string search = "")
        {
            return await DoSuggestionsAsync(search);
        }


        [Route("{Id}/Bets")]
        [HttpGet]
        [ResponseType(typeof(TotalBetCountResponse))]
        public async Task<IHttpActionResult> GetBets(int id, int pageNumber = 1)
        {
            var request = new TotalBetCountAsyncRequest(id, pageNumber);
            var response = await mediator.GetAsync(request);

            return Ok(response);
        }

        [Route("Risks")]
        [HttpGet]
        [ResponseType(typeof(IList<RiskCustomerResponse>))]
        public async Task<IHttpActionResult> GetRisks(int pageNumber = 1)
        {
            var request = new RiskCustomerAsyncRequest(pageNumber);
            var response = await mediator.GetAsync(request);

            return Ok(response);
        }

        protected override Func<IQueryable<Customer>, IOrderedQueryable<Customer>> GetOrderBy(int sortColumn, bool isDesc)
        {
            Func<IQueryable<Customer>, IOrderedQueryable<Customer>> orderBy = r => r.OrderBy(x => x.Name);

            if (isDesc) orderBy = r => r.OrderByDescending(x => x.Name);

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
            search = search.ToLower();

            return await repository
                .GetAutoCompleteIntellisenseAsync(r => search == "" || r.Name.ToLower().Contains(search), r => r.Name);
        }
    }
}