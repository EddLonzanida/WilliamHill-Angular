using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Eml.Contracts.Repositories;
using Eml.Mediator.Contracts;
using TechChallenge.Business.Common.Entities;
using TechChallenge.Business.Helpers;
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

            if (customers == null) return new CustomerResponse(new List<Customer>());
            var response = customers
                .OrderBy(r => r.Name)
                .ThenBy(r => r.Id);
            return new CustomerResponse(response);
        }

        public void Dispose()
        {
            repository?.Dispose();
        }
    }
}
