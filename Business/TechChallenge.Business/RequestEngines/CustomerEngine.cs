using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Eml.Contracts.Repositories;
using Eml.Mediator.Contracts;
using TechChallenge.Business.Common.Entities;
using TechChallenge.Business.Common.Helpers;
using TechChallenge.Business.Requests;
using TechChallenge.Business.Responses;

namespace TechChallenge.Business.RequestEngines
{
    public class CustomerEngine : IRequestAsyncEngine<CustomerRequest, CustomerResponse>
    {
        private readonly IDataRepositorySoftDeleteInt<Customer> repository;

        [ImportingConstructor]
        public CustomerEngine(IDataRepositorySoftDeleteInt<Customer> repository)
        {
            this.repository = repository;
        }

        public async Task<CustomerResponse> GetAsync(CustomerRequest request)
        {
            var customers = await EntityFactory.GetCustomers(repository);

            return customers == null ? new CustomerResponse(new List<Customer>()) : new CustomerResponse(customers);
        }

        public void Dispose()
        {
            repository?.Dispose();
        }
    }
}
