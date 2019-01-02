using NSubstitute;
using Shouldly;
using System;
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
    public class RaceStatEngineTests : EngineTestBase<RaceStatAsyncRequest, RaceStatResponse>
    {
        public RaceStatEngineTests()
        {
            engine = new RaceStatEngine(raceRepository, betRepository);
        }

        [Fact]
        public async Task Engine_ShouldHandleNullData()
        {
            List<Race> nullRaceData = null;
            List<Bet> nullBetData = null;
            raceRepository.GetAsync(Arg.Any<Func<IQueryable<Race>, IQueryable<Race>>>()).Returns(nullRaceData);
            betRepository.GetAllAsync().Returns(nullBetData);
            var request = new RaceStatAsyncRequest(1);

            await engine.GetAsync(request);

            await raceRepository.Received(1).GetAsync(Arg.Any<Func<IQueryable<Race>, IQueryable<Race>>>());
            await betRepository.Received(1).GetAllAsync();
        }

        [Fact]
        public async Task Engine_ShouldReturnRaceStatus()
        {
            raceRepository.GetAsync(Arg.Any<Func<IQueryable<Race>, IQueryable<Race>>>()).Returns(racesStub);
            betRepository.GetAllAsync().Returns(betStub);
            var request = new RaceStatAsyncRequest(1);

            var response = await engine.GetAsync(request);

            response.RaceStats.ToList().TrueForAll(r => !string.IsNullOrWhiteSpace(r.Status)).ShouldBeTrue();
        }

        [Fact]
        public async Task Engine_ShouldSumAllRaceMoney()
        {
            raceRepository.GetAsync(Arg.Any<Func<IQueryable<Race>, IQueryable<Race>>>()).Returns(racesStub);
            betRepository.GetAllAsync().Returns(betStub);
            var request = new RaceStatAsyncRequest(1);

            var response = await engine.GetAsync(request);

            response.RaceStats.Count().ShouldBe(5);
            var r1 = response.RaceStats.First(r => r.Id == 1);
            var r2 = response.RaceStats.First(r => r.Id == 2);
            var r3 = response.RaceStats.First(r => r.Id == 3);
            var r4 = response.RaceStats.First(r => r.Id == 4);
            var r5 = response.RaceStats.First(r => r.Id == 5);
            r1.RaceTotalAmount.ShouldBe(1200);
            r2.RaceTotalAmount.ShouldBe(520);
            r3.RaceTotalAmount.ShouldBe(1200);
            r4.RaceTotalAmount.ShouldBe(900);
            r5.RaceTotalAmount.ShouldBe(1940);
        }

        [Fact]
        public async Task Engine_ShouldReturnAllHorsesPerRace()
        {
            raceRepository.GetAsync(Arg.Any<Func<IQueryable<Race>, IQueryable<Race>>>()).Returns(racesStub);
            betRepository.GetAllAsync().Returns(betStub);
            var request = new RaceStatAsyncRequest(1);

            var response = await engine.GetAsync(request);

            response.RaceStats.Count().ShouldBe(5);
            var r1 = response.RaceStats.First(r => r.Id == 1);
            var r2 = response.RaceStats.First(r => r.Id == 2);
            var r3 = response.RaceStats.First(r => r.Id == 3);
            var r4 = response.RaceStats.First(r => r.Id == 4);
            var r5 = response.RaceStats.First(r => r.Id == 5);
            r1.HorseStats.Count.ShouldBe(3);
            r2.HorseStats.Count.ShouldBe(3);
            r3.HorseStats.Count.ShouldBe(3);
            r4.HorseStats.Count.ShouldBe(3);
            r5.HorseStats.Count.ShouldBe(5);
        }

        [Fact]
        public async Task Engine_ShouldReturnHorseNames()
        {
            raceRepository.GetAsync(Arg.Any<Func<IQueryable<Race>, IQueryable<Race>>>()).Returns(racesStub);
            betRepository.GetAllAsync().Returns(betStub);
            var request = new RaceStatAsyncRequest(1);

            var response = await engine.GetAsync(request);

            response.RaceStats.Count().ShouldBe(5);
            var r1 = response.RaceStats.First(r => r.Id == 1);
            var r2 = response.RaceStats.First(r => r.Id == 2);
            var r3 = response.RaceStats.First(r => r.Id == 3);
            var r4 = response.RaceStats.First(r => r.Id == 4);
            var r5 = response.RaceStats.First(r => r.Id == 5);
            r1.HorseStats.TrueForAll(r => !string.IsNullOrWhiteSpace(r.Name)).ShouldBeTrue();
            r2.HorseStats.TrueForAll(r => !string.IsNullOrWhiteSpace(r.Name)).ShouldBeTrue();
            r3.HorseStats.TrueForAll(r => !string.IsNullOrWhiteSpace(r.Name)).ShouldBeTrue();
            r4.HorseStats.TrueForAll(r => !string.IsNullOrWhiteSpace(r.Name)).ShouldBeTrue();
            r5.HorseStats.TrueForAll(r => !string.IsNullOrWhiteSpace(r.Name)).ShouldBeTrue();
        }

        [Fact]
        public async Task Engine_ShouldReturnHorseBetCount()
        {
            raceRepository.GetAsync(Arg.Any<Func<IQueryable<Race>, IQueryable<Race>>>()).Returns(racesStub);
            betRepository.GetAllAsync().Returns(betStub);
            var request = new RaceStatAsyncRequest(1);

            var response = await engine.GetAsync(request);

            response.RaceStats.Count().ShouldBe(5);
            var r1 = response.RaceStats.First(r => r.Id == 1);
            var r2 = response.RaceStats.First(r => r.Id == 2);
            var r3 = response.RaceStats.First(r => r.Id == 3);
            var r4 = response.RaceStats.First(r => r.Id == 4);
            var r5 = response.RaceStats.First(r => r.Id == 5);
            var r1_h1 = r1.HorseStats.Find(r => r.Id == 11);
            var r1_h2 = r1.HorseStats.Find(r => r.Id == 12);
            var r1_h3 = r1.HorseStats.Find(r => r.Id == 13);
            var r2_h1 = r2.HorseStats.Find(r => r.Id == 21);
            var r2_h2 = r2.HorseStats.Find(r => r.Id == 22);
            var r2_h3 = r2.HorseStats.Find(r => r.Id == 23);
            var r3_h1 = r3.HorseStats.Find(r => r.Id == 31);
            var r3_h2 = r3.HorseStats.Find(r => r.Id == 32);
            var r3_h3 = r3.HorseStats.Find(r => r.Id == 33);
            var r4_h1 = r4.HorseStats.Find(r => r.Id == 41);
            var r4_h2 = r4.HorseStats.Find(r => r.Id == 42);
            var r4_h3 = r4.HorseStats.Find(r => r.Id == 43);
            var r5_h1 = r5.HorseStats.Find(r => r.Id == 51);
            var r5_h2 = r5.HorseStats.Find(r => r.Id == 52);
            var r5_h3 = r5.HorseStats.Find(r => r.Id == 53);
            var r5_h4 = r5.HorseStats.Find(r => r.Id == 54);
            var r5_h5 = r5.HorseStats.Find(r => r.Id == 55);
            r1_h1.BetCount.ShouldBe(2);
            r1_h2.BetCount.ShouldBe(3);
            r1_h3.BetCount.ShouldBe(1);
            r2_h1.BetCount.ShouldBe(2);
            r2_h2.BetCount.ShouldBe(2);
            r2_h3.BetCount.ShouldBe(0);
            r3_h1.BetCount.ShouldBe(2);
            r3_h2.BetCount.ShouldBe(2);
            r3_h3.BetCount.ShouldBe(1);
            r4_h1.BetCount.ShouldBe(0);
            r4_h2.BetCount.ShouldBe(2);
            r4_h3.BetCount.ShouldBe(2);
            r5_h1.BetCount.ShouldBe(1);
            r5_h2.BetCount.ShouldBe(0);
            r5_h3.BetCount.ShouldBe(1);
            r5_h4.BetCount.ShouldBe(3);
            r5_h5.BetCount.ShouldBe(2);
        }

        [Fact]
        public async Task Engine_ShouldReturnTotalHorseWinPrize()
        {
            raceRepository.GetAsync(Arg.Any<Func<IQueryable<Race>, IQueryable<Race>>>()).Returns(racesStub);
            betRepository.GetAllAsync().Returns(betStub);
            var request = new RaceStatAsyncRequest(1);

            var response = await engine.GetAsync(request);

            response.RaceStats.Count().ShouldBe(5);
            var r1 = response.RaceStats.First(r => r.Id == 1);
            var r2 = response.RaceStats.First(r => r.Id == 2);
            var r3 = response.RaceStats.First(r => r.Id == 3);
            var r4 = response.RaceStats.First(r => r.Id == 4);
            var r5 = response.RaceStats.First(r => r.Id == 5);
            var r1_h1 = r1.HorseStats.Find(r => r.Id == 11);
            var r1_h2 = r1.HorseStats.Find(r => r.Id == 12);
            var r1_h3 = r1.HorseStats.Find(r => r.Id == 13);
            var r2_h1 = r2.HorseStats.Find(r => r.Id == 21);
            var r2_h2 = r2.HorseStats.Find(r => r.Id == 22);
            var r2_h3 = r2.HorseStats.Find(r => r.Id == 23);
            var r3_h1 = r3.HorseStats.Find(r => r.Id == 31);
            var r3_h2 = r3.HorseStats.Find(r => r.Id == 32);
            var r3_h3 = r3.HorseStats.Find(r => r.Id == 33);
            var r4_h1 = r4.HorseStats.Find(r => r.Id == 41);
            var r4_h2 = r4.HorseStats.Find(r => r.Id == 42);
            var r4_h3 = r4.HorseStats.Find(r => r.Id == 43);
            var r5_h1 = r5.HorseStats.Find(r => r.Id == 51);
            var r5_h2 = r5.HorseStats.Find(r => r.Id == 52);
            var r5_h3 = r5.HorseStats.Find(r => r.Id == 53);
            var r5_h4 = r5.HorseStats.Find(r => r.Id == 54);
            var r5_h5 = r5.HorseStats.Find(r => r.Id == 55);
            r1_h1.WinAmount.ShouldBe(2200);
            r1_h2.WinAmount.ShouldBe(1050);
            r1_h3.WinAmount.ShouldBe(300);
            r2_h1.WinAmount.ShouldBe(1650);
            r2_h2.WinAmount.ShouldBe(330);
            r2_h3.WinAmount.ShouldBe(0);
            r3_h1.WinAmount.ShouldBe(2200);
            r3_h2.WinAmount.ShouldBe(750);
            r3_h3.WinAmount.ShouldBe(450);
            r4_h1.WinAmount.ShouldBe(0);
            r4_h2.WinAmount.ShouldBe(600);
            r4_h3.WinAmount.ShouldBe(1500);
            r5_h1.WinAmount.ShouldBe(1650);
            r5_h2.WinAmount.ShouldBe(0);
            r5_h3.WinAmount.ShouldBe(3900);
            r5_h4.WinAmount.ShouldBe(10120);
            r5_h5.WinAmount.ShouldBe(6000);
        }
    }
}
