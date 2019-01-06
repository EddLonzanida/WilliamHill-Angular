using Eml.Mediator.Contracts;
using TechChallenge.Business.Common.Responses;

namespace TechChallenge.Business.Common.Requests
{
    public class TotalBetAmountAsyncRequest : IRequestAsync<TotalBetAmountAsyncRequest, TotalBetAmountResponse>
    {
        public int PageNumber { get; } = 1;

        public int CustomerId { get; }

        /// <summary>
        /// This request will be processed by <see cref="TotalBetAmountEngine"/>.
        /// </summary>
        public TotalBetAmountAsyncRequest(int customerId = 0)
        {
            CustomerId = customerId;
        }
    }
}
