using Eml.Mediator.Contracts;
using System.Collections.Generic;
using TechChallenge.Business.Common.Dto;

namespace TechChallenge.Business.Common.Responses
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