using Shouldly;
using System.Linq;
using System.Threading.Tasks;
using TechChallenge.Business.Common.Requests;
using TechChallenge.Tests.Integration.BaseClasses;
using Xunit;

namespace TechChallenge.Tests.Integration.RequestEngines
{
    public class TotalBetCountEngineTests : IntegrationTestDbBase
    {
        [Fact]
        public async Task Engine_ShouldHandleNullData()
        {
            var request = new TotalBetCountAsyncRequest(0, 1);

            var response = await mediator.GetAsync(request);

            response.BetCounts.Count().ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Engine_ShouldReturnCustomerBetCount()
        {
            var request = new TotalBetCountAsyncRequest(0, 1);

            var response = await mediator.GetAsync(request);

            response.BetCounts.Count().ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Engine_ShouldReturnSingleCustomerBetCount()
        {
            var request = new TotalBetCountAsyncRequest(1, 1);

            var response = await mediator.GetAsync(request);

            response.BetCounts.Count().ShouldBeGreaterThan(0);
        }
    }
}

