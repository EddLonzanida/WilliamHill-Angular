using Eml.Mediator.Contracts;
using TechChallenge.Business.Common.Responses;

namespace TechChallenge.Business.Common.Requests
{
    public class TotalBetCountAsyncRequest : IRequestAsync<TotalBetCountAsyncRequest, TotalBetCountResponse>
    {
        /// <summary>
        /// This request will be processed by <see cref="TotalBetCountEngine"/>.
        /// </summary>
        public int CustomerId { get; }

        public int PageNumber { get; }

        public TotalBetCountAsyncRequest(int customerId, int pageNumber)
        {
            CustomerId = customerId;
            PageNumber = pageNumber;
        }
    }
}
