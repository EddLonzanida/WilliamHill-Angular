using Shouldly;
using System.Linq;
using System.Threading.Tasks;
using TechChallenge.Business.Common.Requests;
using TechChallenge.Tests.Integration.BaseClasses;
using Xunit;

namespace TechChallenge.Tests.Integration.RequestEngines
{
    public class CustomerEngineTests : IntegrationTestDbBase
    {
        [Fact]
        public async Task Engine_ShouldRetrieveData()
        {
            var request = new CustomerAsyncRequest(1);

            var response = await mediator.GetAsync(request);

            response.Customers.Count().ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Engine_ShouldHandleNullData()
        {
            var request = new CustomerAsyncRequest(1);

            var response = await mediator.GetAsync(request);

            response.Customers.Count().ShouldBeGreaterThan(0);
        }
    }
}


