using Eml.Mediator.Contracts;
using TechChallenge.Business.Common.Responses;

namespace TechChallenge.Business.Common.Requests
{
    public class TotalBetAmountAsyncRequest : IRequestAsync<TotalBetAmountAsyncRequest, TotalBetAmountResponse>
    {
        public int PageNumber { get; }

        /// <summary>
        /// This request will be processed by <see cref="TotalBetAmountEngine"/>.
        /// </summary>
        public TotalBetAmountAsyncRequest()
        {
            PageNumber = 1;
        }
    }
}
