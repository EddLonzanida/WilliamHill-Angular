using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NSubstitute;
using Shouldly;
using TechChallenge.Business.Common.Entities;
using TechChallenge.Business.RequestEngines;
using TechChallenge.Business.Requests;
using TechChallenge.Business.Responses;
using TechChallenge.Tests.Unit.BaseClasses;
using Xunit;

namespace TechChallenge.Tests.Unit.RequestEngines
{
    public class TotalBetCountEngineTests : EngineTestBase<TotalBetCountRequest, TotalBetCountResponse>
    {
        public TotalBetCountEngineTests()
        {
            engine = new TotalBetCountEngine(betRepository);
        }

        [Fact]
        public async Task Engine_ShouldHandleNullData()
        {
            List<Bet> nullBetData = null;
            betRepository.GetAllAsync().Returns(nullBetData);
            var request = new TotalBetCountRequest(0, 1);

            await engine.GetAsync(request);

            await betRepository.Received(1).GetAllAsync();
        }

        [Fact]
        public async Task Engine_ShouldReturnCustomerBetCount()
        {
            betRepository.GetAllAsync().Returns(betStub);
            var request = new TotalBetCountRequest(0, 1);

            var response = await engine.GetAsync(request);

            response.BetCounts.Count().ShouldBe(7);
            var c1 = response.BetCounts.First(r => r.Id == 1);
            var c2 = response.BetCounts.First(r => r.Id == 2);
            var c3 = response.BetCounts.First(r => r.Id == 3);
            var c4 = response.BetCounts.First(r => r.Id == 4);
            var c5 = response.BetCounts.First(r => r.Id == 5);
            var c6 = response.BetCounts.First(r => r.Id == 6);
            var c7 = response.BetCounts.First(r => r.Id == 7);
            c1.TotalBets.ShouldBe(4);
            c2.TotalBets.ShouldBe(4);
            c3.TotalBets.ShouldBe(3);
            c4.TotalBets.ShouldBe(3);
            c5.TotalBets.ShouldBe(5);
            c6.TotalBets.ShouldBe(5);
            c7.TotalBets.ShouldBe(5);
        }

        [Fact]
        public async Task Engine_ShouldReturnSingleCustomerBetCount()
        {
            betRepository.GetAllAsync().Returns(betStub);
            var request = new TotalBetCountRequest(1, 1);

            var response = await engine.GetAsync(request);

            response.BetCounts.Count().ShouldBe(1);
        }
    }
}
