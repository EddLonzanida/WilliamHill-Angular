using System;
using System.Collections.Generic;
using Eml.Contracts.Repositories;
using Eml.Mediator.Contracts;
using NSubstitute;
using TechChallenge.Business.Common.Entities;
using Eml.DataRepository;

namespace TechChallenge.Tests.Unit.BaseClasses
{
    public abstract class EngineTestBase<T1, T2> : IDisposable
        where T1 : IRequestAsync<T1, T2> where T2 : IResponse
    {
        private const string JSON_SOURCES = @"SampleData";

        protected IRequestAsyncEngine<T1, T2> engine;

        protected readonly List<Race> racesStub;

        protected readonly List<Bet> betStub;

        protected readonly List<Customer> customerStub;

        protected readonly IDataRepositorySoftDeleteInt<Race> raceRepository;

        protected readonly IDataRepositorySoftDeleteInt<Bet> betRepository;

        protected readonly IDataRepositorySoftDeleteInt<Customer> customerRepository;

        protected EngineTestBase()
        {
            racesStub = Seed.GetStubs<Race>("races", JSON_SOURCES);
            betStub = Seed.GetStubs<Bet>("bets", JSON_SOURCES);
            customerStub = Seed.GetStubs<Customer>("customers", JSON_SOURCES);

            raceRepository = Substitute.For<IDataRepositorySoftDeleteInt<Race>>();
            betRepository = Substitute.For<IDataRepositorySoftDeleteInt<Bet>>();
            customerRepository = Substitute.For<IDataRepositorySoftDeleteInt<Customer>>();
        }

        public void Dispose()
        {
            engine?.Dispose();
            raceRepository?.Dispose();
            betRepository?.Dispose();
            customerRepository?.Dispose();
        }
    }
}
