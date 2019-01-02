using Eml.Mediator.Contracts;
using TechChallenge.Business.Common.Responses;

namespace TechChallenge.Business.Common.Requests
{
    public class CustomerAsyncRequest : IRequestAsync<CustomerAsyncRequest, CustomerResponse>
    {
        public int PageNumber { get; }
	
        /// <summary>
        /// This request will be processed by <see cref="CustomerEngine"/>.
        /// </summary>
        public CustomerAsyncRequest(int pageNumber)
        {
            PageNumber = pageNumber;
        }
    }
}
