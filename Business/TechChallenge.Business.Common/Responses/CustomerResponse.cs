using System.Collections.Generic;
using Eml.Mediator.Contracts;
using TechChallenge.Business.Common.Entities.TechChallengeDb;

namespace TechChallenge.Business.Common.Responses
{
    public class CustomerResponse : IResponse
    {
        public IEnumerable<Customer> Customers { get; }

        public CustomerResponse(IEnumerable<Customer> customers)
        {
            Customers = customers;
        }
    }
}