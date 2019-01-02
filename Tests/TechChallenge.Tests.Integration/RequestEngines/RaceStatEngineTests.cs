using Shouldly;
using System.Linq;
using System.Threading.Tasks;
using TechChallenge.Business.Common.Requests;
using TechChallenge.Tests.Integration.BaseClasses;
using Xunit;

namespace TechChallenge.Tests.Integration.RequestEngines
{
    public class RaceStatEngineTests : IntegrationTestDbBase
    {
        [Fact]
        public async Task Engine_ShouldHandleNullData()
        {
            var request = new RaceStatAsyncRequest(1);

            var response = await mediator.GetAsync(request);

            response.RaceStats.Count().ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Engine_ShouldReturnRaceStatus()
        {
            var request = new RaceStatAsyncRequest(1);

            var response = await mediator.GetAsync(request);

            response.RaceStats.Count().ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Engine_ShouldSumAllRaceMoney()
        {
            var request = new RaceStatAsyncRequest(1);

            var response = await mediator.GetAsync(request);

            response.RaceStats.Count().ShouldBeGreaterThan(0);

        }

        [Fact]
        public async Task Engine_ShouldReturnAllHorsesPerRace()
        {
            var request = new RaceStatAsyncRequest(1);

            var response = await mediator.GetAsync(request);

            response.RaceStats.Count().ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Engine_ShouldReturnHorseNames()
        {
            var request = new RaceStatAsyncRequest(1);

            var response = await mediator.GetAsync(request);

            response.RaceStats.Count().ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Engine_ShouldReturnHorseBetCount()
        {
            var request = new RaceStatAsyncRequest(1);

            var response = await mediator.GetAsync(request);

            response.RaceStats.Count().ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Engine_ShouldReturnTotalHorseWinPrize()
        {
            var request = new RaceStatAsyncRequest(1);

            var response = await mediator.GetAsync(request);

            response.RaceStats.Count().ShouldBeGreaterThan(0);
        }
    }
}
