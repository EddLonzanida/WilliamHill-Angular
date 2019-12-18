using NSubstitute;
using Shouldly;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechChallenge.Business.Common.Entities.TechChallengeDb;
using TechChallenge.Business.Common.Requests;
using TechChallenge.Business.Common.Responses;
using TechChallenge.Business.RequestEngines;
using TechChallenge.Tests.Unit.BaseClasses;
using Xunit;

namespace TechChallenge.Tests.Unit.RequestEngines
{
    public class CustomerEngineTests : EngineTestBase<CustomerAsyncRequest, CustomerResponse>
    {
        public CustomerEngineTests()
        {
            engine = new CustomerEngine(customerRepository);
        }

        [Fact]
        public async Task Engine_ShouldRetrieveData()
        {
            customerRepository.GetAllAsync().Returns(customerStub);
            var request = new CustomerAsyncRequest(1);

            await engine.GetAsync(request);

            await customerRepository.Received(1).GetAllAsync();
        }

        [Fact]
        public async Task Engine_ShouldHandleNullData()
        {
            customerRepository.GetAllAsync().Returns((List<Customer>) null);
            var request = new CustomerAsyncRequest(1);

            var response = await engine.GetAsync(request);

            await customerRepository.Received(1).GetAllAsync();
            response.Customers.ShouldNotBeNull();
        }
    }
}
