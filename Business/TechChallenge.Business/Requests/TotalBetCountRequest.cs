using Eml.Mediator.Contracts;
using TechChallenge.Business.Responses;

namespace TechChallenge.Business.Requests
{
    public class TotalBetCountRequest : IRequestAsync<TotalBetCountRequest, TotalBetCountResponse>
    {
        public int CustomerId { get; }

        public int PageNumber { get; }

        public TotalBetCountRequest(int customerId, int pageNumber)
        {
            CustomerId = customerId;
            PageNumber = pageNumber;
        }
    }
}
