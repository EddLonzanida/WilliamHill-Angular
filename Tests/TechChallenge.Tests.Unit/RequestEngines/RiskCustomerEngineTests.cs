﻿using NSubstitute;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechChallenge.Business.Common.Entities.TechChallengeDb;
using TechChallenge.Business.Common.Requests;
using TechChallenge.Business.Common.Responses;
using TechChallenge.Business.RequestEngines;
using TechChallenge.Tests.Unit.BaseClasses;
using Xunit;

namespace TechChallenge.Tests.Unit.RequestEngines
{
    public class RiskCustomerEngineTests : EngineTestBase<RiskCustomerAsyncRequest, RiskCustomerResponse>
    {
        public RiskCustomerEngineTests()
        {
            engine = new RiskCustomerEngine(customerRepository, betRepository);
        }

        [Fact]
        public async Task Engine_ShouldHandleNullData()
        {
            List<Bet> nullBetData = null;
            betRepository.GetAllAsync().Returns(nullBetData);

            var request = new RiskCustomerAsyncRequest(1);

            await engine.GetAsync(request);

            await betRepository.Received(1).GetAllAsync();
        }

        [Fact]
        public async Task Engine_ShouldReturnRiskCustomers()
        {
            betRepository.GetAllAsync().Returns(betStub);
            customerRepository.GetAllAsync().Returns(customerStub);
            var request = new RiskCustomerAsyncRequest(1);

            var response = await engine.GetAsync(request);

            response.RiskCustomers.Count().ShouldBe(7);
            var c1 = response.RiskCustomers.First(r => r.Id == 1);
            var c2 = response.RiskCustomers.First(r => r.Id == 2);
            var c3 = response.RiskCustomers.First(r => r.Id == 3);
            var c4 = response.RiskCustomers.First(r => r.Id == 4);
            var c5 = response.RiskCustomers.First(r => r.Id == 5);
            var c6 = response.RiskCustomers.First(r => r.Id == 6);
            var c7 = response.RiskCustomers.First(r => r.Id == 7);
            c1.Bets.Count.ShouldBe(1);
            c2.Bets.Count.ShouldBe(1);
            c3.Bets.Count.ShouldBe(2);
            c4.Bets.Count.ShouldBe(1);
            c5.Bets.Count.ShouldBe(3);
            c6.Bets.Count.ShouldBe(3);
            c7.Bets.Count.ShouldBe(3);
        }
    }
}
