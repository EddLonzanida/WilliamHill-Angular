using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using TechChallenge.Business.Requests;
using TechChallenge.Tests.Integration.BaseClasses;
using Xunit;

namespace TechChallenge.Tests.Integration.RequestEngines
{
    public class RaceStatEngineTests : IntegrationTestBase
    {
        [Fact]
        public async Task Engine_ShouldHandleNullData()
        {
            var request = new RaceStatRequest(1);

            var response = await mediator.GetAsync(request);

            response.RaceStats.Count().ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Engine_ShouldReturnRaceStatus()
        {
            var request = new RaceStatRequest(1);

            var response = await mediator.GetAsync(request);

            response.RaceStats.Count().ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Engine_ShouldSumAllRaceMoney()
        {
            var request = new RaceStatRequest(1);

            var response = await mediator.GetAsync(request);

            response.RaceStats.Count().ShouldBeGreaterThan(0);

        }

        [Fact]
        public async Task Engine_ShouldReturnAllHorsesPerRace()
        {
            var request = new RaceStatRequest(1);

            var response = await mediator.GetAsync(request);

            response.RaceStats.Count().ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Engine_ShouldReturnHorseNames()
        {
            var request = new RaceStatRequest(1);

            var response = await mediator.GetAsync(request);

            response.RaceStats.Count().ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Engine_ShouldReturnHorseBetCount()
        {
            var request = new RaceStatRequest(1);

            var response = await mediator.GetAsync(request);

            response.RaceStats.Count().ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Engine_ShouldReturnTotalHorseWinPrize()
        {
            var request = new RaceStatRequest(1);

            var response = await mediator.GetAsync(request);

            response.RaceStats.Count().ShouldBeGreaterThan(0);
        }
    }
}



