using Eml.Contracts.Response;
using Eml.ControllerBase;
using Eml.Mediator.Contracts;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TechChallenge.Api.Controllers.BaseClasses;
using TechChallenge.Api.Utils;
using TechChallenge.Business.Common.Dto;
using TechChallenge.Business.Common.Entities;
using TechChallenge.Business.Common.Requests;
using TechChallenge.Business.Common.Responses;
using TechChallenge.Data;
using TechChallenge.Data.Contracts;

namespace TechChallenge.Api.Controllers
{
    [RoutePrefix("Customers")]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CustomersController : CrudControllerApiBase<Customer, IndexRequest>
    {
        [ImportingConstructor]
        public CustomersController(IMediator mediator, IDataRepositorySoftDeleteInt<Customer> repository)
            : base(mediator, repository)
        {
        }

        [Route("DownloadReport")]
        [SwaggerResponseContentType(responseType: "application/octet-stream", Exclusive = true)]
        [HttpPost]
        [ResponseType(typeof(MemoryStream))]
        public async Task<HttpResponseMessage> DownloadReport(string fileName)
        {
            using (var xls = ExcelUtil.CreateCustomerExcel(fileName))
            {
                var memoryStream = await ExcelUtil.GetCustomers(repository, xls);
                var response = Request.CreateResponse(HttpStatusCode.OK);

                response.Content = new ByteArrayContent(memoryStream.GetBuffer());

                SetResponseHeaders(response.Content, xls, memoryStream);

                return response;
            }
        }

        private void SetResponseHeaders(HttpContent content, ExcelPackage xls, MemoryStream memoryStream)
        {
            content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            content.Headers.ContentDisposition.FileName = xls.Workbook.Properties.Title;
            content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-excel");
            content.Headers.ContentLength = memoryStream.Length;
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
            var result = await DoDetailsAsync(id);

            return result;
        }

        [Route("{id}")]
        [HttpPut]
        public override async Task<IHttpActionResult> Edit(int id, [FromBody]Customer item)
        {
            return await DoEditAsync(id, item);
        }

        [Route("")]
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

        [Route("Suggestions")]
        [HttpGet]
        [ResponseType(typeof(string[]))]
        public override async Task<IHttpActionResult> Suggestions(string search = "")
        {
            return await DoSuggestionsAsync(search);
        }

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

        protected override Func<IQueryable<Customer>, IOrderedQueryable<Customer>> GetOrderBy(int sortColumn, bool isDesc)
        {
            Func<IQueryable<Customer>, IOrderedQueryable<Customer>> orderBy = r => r.OrderBy(x => x.Name);

            if (isDesc) orderBy = r => r.OrderByDescending(x => x.Name);

            return orderBy;
        }

        protected override async Task<Customer> DeleteItemAsync(TechChallengeDb db, int id, string reason)
        {
            return await repository.DeleteAsync(db, id, reason);
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