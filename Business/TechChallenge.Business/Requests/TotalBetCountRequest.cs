using Eml.Mediator.Contracts;
using TechChallenge.Business.Responses;

namespace TechChallenge.Business.Requests
{
    public class TotalBetCountRequest : IRequestAsync<TotalBetCountRequest, TotalBetCountResponse>
    {
        public int CustomerId { get; set; }
        public TotalBetCountRequest(int customerId)
        {
            CustomerId = customerId;
        }
    }
}
