using Shouldly;
using System.Linq;
using System.Threading.Tasks;
using TechChallenge.Business.Common.Requests;
using TechChallenge.Tests.Integration.BaseClasses;
using Xunit;

namespace TechChallenge.Tests.Integration.RequestEngines
{
    public class RiskCustomerEngineTests : IntegrationTestDbBase
    {
        [Fact]
        public async Task Engine_ShouldHandleNullData()
        {
            var request = new RiskCustomerAsyncRequest(1);

            var response = await mediator.GetAsync(request);

            response.RiskCustomers.Count().ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Engine_ShouldReturnRiskCustomers()
        {
            var request = new RiskCustomerAsyncRequest(1);

            var response = await mediator.GetAsync(request);

            response.RiskCustomers.Count().ShouldBeGreaterThan(0);
        }
    }
}
