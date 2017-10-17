using System.Collections.Generic;
using Eml.Mediator.Contracts;
using TechChallenge.Business.Common.Dto;

namespace TechChallenge.Business.Responses
{
    public class TotalBetAmountResponse : IResponse
    {
        public IEnumerable<CustomerBetAmount> CustomerBets { get; }
        public TotalBetAmountResponse(IEnumerable<CustomerBetAmount> customerBets)
        {
            CustomerBets = customerBets;
        }
    }
}
