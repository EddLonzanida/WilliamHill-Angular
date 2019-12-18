using Eml.Contracts.Responses;
using TechChallenge.Api.Controllers.BaseClasses.TechChallengeDb;
using TechChallenge.Business.Common.Dto.TechChallengeDb;
using TechChallenge.Business.Common.Dto.TechChallengeDb.EntityHelpers;
using TechChallenge.Business.Common.Dto.TechChallengeDb.SortEnums;
using TechChallenge.Business.Common.Entities.TechChallengeDb;
using TechChallenge.Data.Repositories.TechChallengeDb.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Eml.Mediator.Contracts;
using TechChallenge.Business.Common.Dto;
using TechChallenge.Business.Common.Requests;
using TechChallenge.Business.Common.Responses;

namespace TechChallenge.Api.Controllers
{
    [RoutePrefix("api/Customer")]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CustomerController : CrudControllerApiSoftDeletableIntBase<Customer
        , CustomerIndexRequest
        , CustomerIndexResponse
        , CustomerEditCreateRequest
        , CustomerDetailsCreateResponse
        , ITechChallengeDataRepositorySoftDeleteInt<Customer>>
    {
        [ImportingConstructor]
        public CustomerController(IMediator mediator, ITechChallengeDataRepositorySoftDeleteInt<Customer> repository)
            : base(mediator, repository)
        {
        }

        #region CRUD
        [Route("")]
        [HttpGet]
        [ResponseType(typeof(CustomerIndexResponse))]
        public override async Task<IHttpActionResult> Index([FromUri]CustomerIndexRequest request)
        {
            return await DoIndexAsync(request);
        }

        [Route("Suggestions")]
        [ResponseType(typeof(List<string>))]
        public override async Task<IHttpActionResult> Suggestions(string search = "")
        {
            return await DoSuggestionsAsync(search);
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(CustomerDetailsCreateResponse))]
        public override async Task<IHttpActionResult> Details(int id)
        {
            return await DoDetailsAsync(id);
        }

        [Route("")]
        [HttpPost]
        [ResponseType(typeof(CustomerDetailsCreateResponse))]
        public override async Task<IHttpActionResult> Create([FromBody]CustomerEditCreateRequest request)
        {
            return await DoCreateAsync(request);
        }

        [Route("")]
        [HttpPut]
        public override async Task<IHttpActionResult> Edit([FromBody]CustomerEditCreateRequest request)
        {
            return await DoEditAsync(request);
        }

        [Route("{id}")]
        [HttpDelete]
        public override async Task<IHttpActionResult> Delete(int id, [FromBody]string reason)
        {
            return await DoDeleteAsync(id, reason);
        }
        #endregion // CRUD

        #region BETS
        [Route("{Id}/BetCount")]
        [HttpGet]
        [ResponseType(typeof(TotalBetCountResponse))]
        public async Task<IHttpActionResult> GetBetCount(int id)
        {
            const int pageNumber = 1;

            var request = new TotalBetCountAsyncRequest(id, pageNumber);
            var response = await mediator.GetAsync(request);

            return Ok(response);
        }

        [Route("BetAmount")]
        [HttpGet]
        [ResponseType(typeof(TotalBetAmountResponse))]
        public async Task<IHttpActionResult> GetBetAmount()
        {
            var request = new TotalBetAmountAsyncRequest();
            var response = await mediator.GetAsync(request);

            return Ok(response);
        }

        [Route("{Id}/BetAmount")]
        [HttpGet]
        [ResponseType(typeof(CustomerBetAmount))]
        public async Task<IHttpActionResult> GetBetAmount(int id)
        {
            var request = new TotalBetAmountAsyncRequest(id);
            var betAmount = await mediator.GetAsync(request);
            var response = betAmount.CustomerBets.FirstOrDefault(r => r.Id == id);

            return Ok(response);
        }

        [Route("Risk")]
        [HttpGet]
        [ResponseType(typeof(IList<RiskCustomerResponse>))]
        public async Task<IHttpActionResult> GetRisk()
        {
            const int pageNumber = 1;

            var request = new RiskCustomerAsyncRequest(pageNumber);
            var response = await mediator.GetAsync(request);

            return Ok(response);
        }
        #endregion // BETS

        #region CRUD HELPERS
        protected override async Task<CustomerDetailsCreateResponse> EditItemAsync(CustomerEditCreateRequest request)
        {
            var entity = request.ToEntity();

            await repository.UpdateAsync(entity);

            return entity.ToDto();
        }

        protected override async Task<CustomerDetailsCreateResponse> AddItemAsync(CustomerEditCreateRequest request)
        {
            var entity = request.ToEntity();
            
            var newEntity = await repository.AddAsync(entity);

            return newEntity.ToDto();
        }

        protected override async Task<List<string>> GetSuggestionsAsync(string search = "")
        {
            search = string.IsNullOrWhiteSpace(search) ? string.Empty : search;

            return await repository
                .GetAutoCompleteIntellisenseAsync(r => search == "" || r.Name.Contains(search)
                    , r => r.Name);
        }

        protected override async Task<CustomerIndexResponse> GetItemsAsync(CustomerIndexRequest request)
        {
            var search = request.Search;

            Expression<Func<Customer, bool>> whereClause = r => search == null
                                                               || search == ""
                                                               || r.Name.Contains(search);

            var items = await GetItemsAsync(request, whereClause);

            return new CustomerIndexResponse(items.Items, items.RecordCount, items.RowsPerPage);
        }

        protected async Task<SearchResponse<Customer>> GetItemsAsync(CustomerIndexRequest request, Expression<Func<Customer, bool>> whereClause)
        {
            var orderBy = GetOrderBy(request.SortColumn, request.IsDescending);
            var result = await repository.GetPagedListAsync(request.Page, whereClause, orderBy);
            var response = new SearchResponse<Customer>(result.ToList(), result.TotalItemCount, result.PageSize);

            return response;
        }

        protected Func<IQueryable<Customer>, IOrderedQueryable<Customer>> GetOrderBy(string sortColumn, bool isDesc)
        {
            Func<IQueryable<Customer>, IOrderedQueryable<Customer>> orderBy;

            if (string.IsNullOrWhiteSpace(sortColumn))
            {
                sortColumn = "Name"; //Default sort column
            }

            var eSortColumn = (eCustomer)Enum.Parse(typeof(eCustomer), sortColumn, true);

            if (isDesc)
            {
                switch (eSortColumn)
                {
                    case eCustomer.Name:

                        orderBy = r => r.OrderByDescending(x => x.Name);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException($"sortColumn: [{sortColumn}] is not supported.");
                }

                return orderBy;
            }

            switch (eSortColumn)
            {
                case eCustomer.Name:

                    orderBy = r => r.OrderBy(x => x.Name);
                    break;

                default:
                    throw new ArgumentOutOfRangeException($"sortColumn: [{sortColumn}] is not supported.");
            }

            return orderBy;
        }

        protected override async Task<CustomerDetailsCreateResponse> GetItemAsync(int id)
        {
            var item = await repository.GetAsync(id);

            return item?.ToDto();
        }
        #endregion // CRUD HELPERS
    }
}
