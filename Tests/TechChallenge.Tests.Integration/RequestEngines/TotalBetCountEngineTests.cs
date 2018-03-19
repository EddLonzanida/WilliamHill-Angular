using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using TechChallenge.Business.Requests;
using TechChallenge.Tests.Integration.BaseClasses;
using Xunit;

namespace TechChallenge.Tests.Integration.RequestEngines
{
    public class TotalBetCountEngineTests : IntegrationTestDbBase
    {
        [Fact]
        public async Task Engine_ShouldHandleNullData()
        {
            var request = new TotalBetCountRequest(0, 1);

            var response = await mediator.GetAsync(request);

            response.BetCounts.Count().ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Engine_ShouldReturnCustomerBetCount()
        {
            var request = new TotalBetCountRequest(0, 1);

            var response = await mediator.GetAsync(request);

            response.BetCounts.Count().ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Engine_ShouldReturnSingleCustomerBetCount()
        {
            var request = new TotalBetCountRequest(1, 1);

            var response = await mediator.GetAsync(request);

            response.BetCounts.Count().ShouldBeGreaterThan(0);
        }
    }
}

