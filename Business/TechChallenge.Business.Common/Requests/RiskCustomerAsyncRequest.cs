using Eml.Mediator.Contracts;
using TechChallenge.Business.Common.Responses;

namespace TechChallenge.Business.Common.Requests
{
    public class RiskCustomerAsyncRequest : IRequestAsync<RiskCustomerAsyncRequest, RiskCustomerResponse>
    {
        public int PageNumber { get; }

	    /// <summary>
        /// This request will be processed by <see cref="RiskCustomerEngine"/>.
        /// </summary>
        public RiskCustomerAsyncRequest(int pageNumber)
        {
            PageNumber = pageNumber;
        }
    }
}
