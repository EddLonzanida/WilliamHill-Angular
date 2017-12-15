using Eml.Mediator.Contracts;
using TechChallenge.Business.Responses;

namespace TechChallenge.Business.Requests
{
    public class CustomerRequest : IRequestAsync<CustomerRequest, CustomerResponse>
    {
        public int PageNumber { get; }

        public CustomerRequest(int pageNumber)
        {
            PageNumber = pageNumber;
        }
    }
}
