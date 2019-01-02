using Shouldly;
using System.Linq;
using System.Threading.Tasks;
using TechChallenge.Business.Common.Requests;
using TechChallenge.Tests.Integration.BaseClasses;
using Xunit;

namespace TechChallenge.Tests.Integration.RequestEngines
{
    public class TotalBetAmountEngineTests : IntegrationTestDbBase
    {
        [Fact]
        public async Task Engine_ShouldHandleNullData()
        {
            var request = new TotalBetAmountAsyncRequest();

            var response = await mediator.GetAsync(request);

            response.CustomerBets.Count().ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Engine_ShouldReturnAmountBetPerCustomer()
        {
            var request = new TotalBetAmountAsyncRequest();

            var response = await mediator.GetAsync(request);

            response.CustomerBets.Count().ShouldBeGreaterThan(0);
        }
    }
}

