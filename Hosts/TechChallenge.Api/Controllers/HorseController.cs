using Eml.Contracts.Requests;
using Eml.Contracts.Responses;
using Eml.Extensions;
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

namespace TechChallenge.Api.Controllers
{
    [RoutePrefix("api/Horse")]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HorseController : CrudControllerApiSoftDeletableIntBase<Horse
        , HorseIndexRequest
        , HorseIndexResponse
        , HorseEditCreateRequest
        , HorseDetailsCreateResponse
        , ITechChallengeDataRepositorySoftDeleteInt<Horse>>
    {
        [ImportingConstructor]
        public HorseController(ITechChallengeDataRepositorySoftDeleteInt<Horse> repository)
            : base(repository)
        {
        }

        #region CRUD
        [Route("")]
        [HttpGet]
        [ResponseType(typeof(HorseIndexResponse))]
        public override async Task<IHttpActionResult> Index([FromUri]HorseIndexRequest request)
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
        [ResponseType(typeof(HorseDetailsCreateResponse))]
        public override async Task<IHttpActionResult> Details(int id)
        {
            return await DoDetailsAsync(id);
        }

        [Route("")]
        [HttpPost]
        [ResponseType(typeof(HorseDetailsCreateResponse))]
        public override async Task<IHttpActionResult> Create([FromBody]HorseEditCreateRequest request)
        {
            return await DoCreateAsync(request);
        }

        [Route("")]
        [HttpPut]
        public override async Task<IHttpActionResult> Edit([FromBody]HorseEditCreateRequest request)
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

        #region CRUD HELPERS
        protected override async Task<HorseDetailsCreateResponse> EditItemAsync(HorseEditCreateRequest request)
        {
            var entity = request.ToEntity();

            await repository.UpdateAsync(entity);

            return entity.ToDto();
        }

        protected override async Task<HorseDetailsCreateResponse> AddItemAsync(HorseEditCreateRequest request)
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

        protected override async Task<HorseIndexResponse> GetItemsAsync(HorseIndexRequest request)
        {
            var search = request.Search;

            Expression<Func<Horse, bool>> whereClause = r => search == null
                                                               || search == ""
                                                               || r.Name.Contains(search);

            var items = await GetItemsAsync(request, whereClause);

            return new HorseIndexResponse(items.Items, items.RecordCount, items.RowsPerPage);
        }

        protected async Task<SearchResponse<Horse>> GetItemsAsync(HorseIndexRequest request, Expression<Func<Horse, bool>> whereClause)
        {
            var orderBy = GetOrderBy(request.SortColumn, request.IsDescending);
            var result = await repository.GetPagedListAsync(request.Page, whereClause, orderBy);
            var response = new SearchResponse<Horse>(result.ToList(), result.TotalItemCount, result.PageSize);

            return response;
        }

        protected Func<IQueryable<Horse>, IOrderedQueryable<Horse>> GetOrderBy(string sortColumn, bool isDesc)
        {
            Func<IQueryable<Horse>, IOrderedQueryable<Horse>> orderBy;

            if (string.IsNullOrWhiteSpace(sortColumn))
            {
                sortColumn = "Name"; //Default sort column
            }

            var eSortColumn = (eHorse)Enum.Parse(typeof(eHorse), sortColumn, true);

            if (isDesc)
            {
                switch (eSortColumn)
                {
                    case eHorse.Name:

                        orderBy = r => r.OrderByDescending(x => x.Name);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException($"sortColumn: [{sortColumn}] is not supported.");
                }

                return orderBy;
            }

            switch (eSortColumn)
            {
                case eHorse.Name:

                    orderBy = r => r.OrderBy(x => x.Name);
                    break;

                default:
                    throw new ArgumentOutOfRangeException($"sortColumn: [{sortColumn}] is not supported.");
            }

            return orderBy;
        }

        protected override async Task<HorseDetailsCreateResponse> GetItemAsync(int id)
        {
            var item = await repository.GetAsync(id);

            return item?.ToDto();
        }
        #endregion // CRUD HELPERS
    }
}
