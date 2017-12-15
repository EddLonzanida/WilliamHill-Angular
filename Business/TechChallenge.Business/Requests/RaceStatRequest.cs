using Eml.Mediator.Contracts;
using TechChallenge.Business.Responses;

namespace TechChallenge.Business.Requests
{
    public class RaceStatRequest : IRequestAsync<RaceStatRequest, RaceStatResponse>
    {
        public int PageNumber { get; }

        public RaceStatRequest(int pageNumber)
        {
            PageNumber = pageNumber;
        }
    }
}
