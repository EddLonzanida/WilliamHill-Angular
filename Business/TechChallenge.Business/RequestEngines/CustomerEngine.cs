using Eml.Mediator.Contracts;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using TechChallenge.Business.Common.Entities.TechChallengeDb;
using TechChallenge.Business.Common.Requests;
using TechChallenge.Business.Common.Responses;
using TechChallenge.Business.Helpers;
using TechChallenge.Data.Repositories.TechChallengeDb.Contracts;

namespace TechChallenge.Business.RequestEngines
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CustomerEngine : IRequestAsyncEngine<CustomerAsyncRequest, CustomerResponse>
    {
        private readonly ITechChallengeDataRepositorySoftDeleteInt<Customer> repository;

        [ImportingConstructor]
        public CustomerEngine(ITechChallengeDataRepositorySoftDeleteInt<Customer> repository)
        {
            this.repository = repository;
        }

        public async Task<CustomerResponse> GetAsync(CustomerAsyncRequest request)
        {
            var customers = await EntityFactory.GetCustomers(repository);

            return customers == null ? new CustomerResponse(new List<Customer>()) : new CustomerResponse(customers);
        }

        public void Dispose()
        {
        }
    }
}
