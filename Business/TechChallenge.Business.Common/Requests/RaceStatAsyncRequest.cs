using Eml.Mediator.Contracts;
using TechChallenge.Business.Common.Responses;

namespace TechChallenge.Business.Common.Requests
{
    public class RaceStatAsyncRequest : IRequestAsync<RaceStatAsyncRequest, RaceStatResponse>
    {
        public int PageNumber { get; }
	    /// <summary>
        /// This request will be processed by <see cref="RaceStatEngine"/>.
        /// </summary>
        public RaceStatAsyncRequest(int pageNumber)
        {
            PageNumber = pageNumber;
        }
    }
}
