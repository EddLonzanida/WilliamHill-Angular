using Eml.Mediator.Contracts;
using TechChallenge.Business.Responses;

namespace TechChallenge.Business.Requests
{
    public class RiskCustomerRequest : IRequestAsync<RiskCustomerRequest, RiskCustomerResponse>
    {
        public int PageNumber { get; }

        public RiskCustomerRequest(int pageNumber)
        {
            PageNumber = pageNumber;
        }
    }
}
