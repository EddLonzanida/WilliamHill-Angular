using System.Collections.Generic;
using Eml.Mediator.Contracts;
using TechChallenge.Business.Common.Dto;

namespace TechChallenge.Business.Responses
{
    public class RiskCustomerResponse : IResponse
    {
        public IEnumerable<RiskCustomer> RiskCustomers { get; }

        public RiskCustomerResponse(IEnumerable<RiskCustomer> riskCustomers)
        {
            RiskCustomers = riskCustomers;
        }
    }
}
