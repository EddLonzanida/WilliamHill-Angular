using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using TechChallenge.Business.Requests;
using TechChallenge.Tests.Integration.BaseClasses;
using Xunit;

namespace TechChallenge.Tests.Integration.RequestEngines
{
    public class TotalBetAmountEngineTests : IntegrationTestBase
    {
        [Fact]
        public async Task Engine_ShouldHandleNullData()
        {
            var request = new TotalBetAmountRequest();

            var response = await mediator.GetAsync(request);

            response.CustomerBets.Count().ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Engine_ShouldReturnAmountBetPerCustomer()
        {
            var request = new TotalBetAmountRequest();

            var response = await mediator.GetAsync(request);

            response.CustomerBets.Count().ShouldBeGreaterThan(0);
        }
    }
}

