using Eml.Mediator.Contracts;
using TechChallenge.Business.Responses;

namespace TechChallenge.Business.Requests
{
    public class TotalBetAmountRequest : IRequestAsync<TotalBetAmountRequest, TotalBetAmountResponse>
    {
        public int PageNumber { get; }

        public TotalBetAmountRequest()
        {
            PageNumber = 1;
        }
    }
}
