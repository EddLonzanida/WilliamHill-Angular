using System.Collections.Generic;
using Eml.Mediator.Contracts;
using TechChallenge.Business.Common.Dto;

namespace TechChallenge.Business.Responses
{
    public class TotalBetCountResponse : IResponse
    {
        public IEnumerable<CustomerBetCount> BetCounts { get; }

        public TotalBetCountResponse(IEnumerable<CustomerBetCount> betCounts)
        {
            BetCounts = betCounts;
        }
    }
}
