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
using Eml.Extensions;
using Eml.Mediator.Contracts;
using TechChallenge.Business.Common.Entities;

namespace TechChallenge.Api.Controllers
{
    [RoutePrefix("api/Horse")]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HorseController : CrudControllerApiWithParentBase<int, Horse, IndexWithParentRequest<int>>
    {
        [ImportingConstructor]
        public HorseController(IMediator mediator, IDataRepositorySoftDeleteInt<Horse> repository)
            : base(mediator, repository)
        {
        }

        [Route("")]
        [HttpGet]
        [ResponseType(typeof(SearchResponse<Horse>))]
        public override async Task<IHttpActionResult> Index(int? page = 1, bool? desc = false, int? sortColumn = 0, string search = "")
        {
            var request = new IndexWithParentRequest<int>(default, page, desc, sortColumn, search, false);
            var response = await DoIndexAsync(request);

            return Ok(response);
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(Horse))]
        public override async Task<IHttpActionResult> Details(int id)
        {
            return await DoDetailsAsync(id);
        }

        [Route("{id}")]
        [HttpPut]
        public override async Task<IHttpActionResult> Edit(int id, [FromBody]Horse item)
        {
            return await DoEditAsync(id, item);
        }

        [HttpPost]
        [ResponseType(typeof(Horse))]
        public override async Task<IHttpActionResult> Create([FromBody]Horse item)
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

        [Route("{parentId}/Index")]
        [HttpGet]
        [ResponseType(typeof(SearchResponse<Horse>))]
        public override async Task<IHttpActionResult> IndexWithParent(int parentId, int? page, bool? desc, int? sortColumn, string search = "")
        {
            var request = new IndexWithParentRequest<int>(parentId, page, desc, sortColumn, search);
            var response = await DoIndexWithParentAsync(request);

            return Ok(response);
        }

        [Route("{parentId}/Suggestions")]
        [HttpGet]
        [ResponseType(typeof(string[]))]
        public override async Task<IHttpActionResult> SuggestionsWithParent(int parentId, string search = "")
        {
            return await DoSuggestionsWithParentAsync(parentId, search);
        }

        protected override async Task<ISearchResponse<Horse>> GetItemsAsync(IndexWithParentRequest<int> request)
        {
            var search = request.Search.ToLower();

            Expression<Func<Horse, bool>> whereClause = r => search == null || search == "" || r.Name.ToLower().Contains(search);

            if (request.HasParent)
            {
                whereClause = whereClause.And(r => r.RaceId == request.ParentId);
            }

            var orderBy = GetOrderBy(request.SortColumn, request.IsDescending);
            var items = await repository.GetPagedListAsync(request.Page, whereClause, orderBy);
            var response = new SearchResponse<Horse>(items, items.TotalItemCount, repository.PageSize);

            return response;
        }

        protected override async Task<List<string>> GetSuggestionsAsync(string search = "")
        {
            search = search.ToLower();

            return await repository
				.GetAutoCompleteIntellisenseAsync(r => search == "" || r.Name.ToLower().Contains(search) , r => r.Name);
        }
		
        protected override async Task<List<string>> GetSuggestionsAsync(int parentId, string search = "")
        {
            search = search.ToLower();

            return await repository
                .GetAutoCompleteIntellisenseAsync(r => r.RaceId == parentId && (search == "" || r.Name.ToLower().Contains(search)) , r => r.Name);
        }

        protected override Func<IQueryable<Horse>, IOrderedQueryable<Horse>> GetOrderBy(int sortColumn, bool isDesc)
        {
            Func<IQueryable<Horse>, IOrderedQueryable<Horse>> orderBy = null;

            var eSortColumn = (eHorse)sortColumn;

            if (isDesc)
            {
                switch (eSortColumn)
                {
					case eHorse.Name:

                        orderBy = r => r.OrderByDescending(x => x.Name);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                return orderBy;
            }

            switch (eSortColumn)
            {
				case eHorse.Name:

                    orderBy = r => r.OrderBy(x => x.Name);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            return orderBy;
        }
    }
}