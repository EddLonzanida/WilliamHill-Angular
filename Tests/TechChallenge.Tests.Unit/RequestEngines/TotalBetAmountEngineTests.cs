using NSubstitute;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechChallenge.Business.Common.Entities;
using TechChallenge.Business.Common.Requests;
using TechChallenge.Business.Common.Responses;
using TechChallenge.Business.RequestEngines;
using TechChallenge.Tests.Unit.BaseClasses;
using Xunit;

namespace TechChallenge.Tests.Unit.RequestEngines
{
    public class TotalBetAmountEngineTests : EngineTestBase<TotalBetAmountAsyncRequest, TotalBetAmountResponse>
    {
        public TotalBetAmountEngineTests()
        {
            engine = new TotalBetAmountEngine(betRepository);
        }

        [Fact]
        public async Task Engine_ShouldHandleNullData()
        {
            List<Bet> nullBetData = null;
            betRepository.GetAllAsync().Returns(nullBetData);

            var request = new TotalBetAmountAsyncRequest();

            await engine.GetAsync(request);

            await betRepository.Received(1).GetAllAsync();
        }

        [Fact]
        public async Task Engine_ShouldReturnAmountBetPerCustomer()
        {
            betRepository.GetAllAsync().Returns(betStub);
            var request = new TotalBetAmountAsyncRequest();

            var response = await engine.GetAsync(request);

            response.CustomerBets.Count().ShouldBe(7);
            var c1 = response.CustomerBets.First(r => r.Id == 1);
            var c2 = response.CustomerBets.First(r => r.Id == 2);
            var c3 = response.CustomerBets.First(r => r.Id == 3);
            var c4 = response.CustomerBets.First(r => r.Id == 4);
            var c5 = response.CustomerBets.First(r => r.Id == 5);
            var c6 = response.CustomerBets.First(r => r.Id == 6);
            var c7 = response.CustomerBets.First(r => r.Id == 7);
            c1.Totalstake.ShouldBe(700);
            c2.Totalstake.ShouldBe(750);
            c3.Totalstake.ShouldBe(650);
            c4.Totalstake.ShouldBe(600);
            c5.Totalstake.ShouldBe(1120);
            c6.Totalstake.ShouldBe(1120);
            c7.Totalstake.ShouldBe(1120);

        }
    }
}
