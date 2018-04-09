using System;
using System.Collections.Generic;
using Eml.Mediator.Contracts;
using NSubstitute;
using TechChallenge.Business.Common.Entities;
using Eml.DataRepository;
using Eml.DataRepository.Contracts;

namespace TechChallenge.Tests.Unit.BaseClasses
{
    public abstract class EngineTestBase<T1, T2> : IDisposable
        where T1 : IRequestAsync<T1, T2> where T2 : IResponse
    {
        private const string SAMPLE_DATA_SOURCES = @"SampleDataSources";

        protected IRequestAsyncEngine<T1, T2> engine;

        protected readonly List<Race> racesStub;

        protected readonly List<Bet> betStub;

        protected readonly List<Customer> customerStub;

        protected readonly IDataRepositorySoftDeleteInt<Race> raceRepository;

        protected readonly IDataRepositorySoftDeleteInt<Bet> betRepository;

        protected readonly IDataRepositorySoftDeleteInt<Customer> customerRepository;

        protected EngineTestBase()
        {
            racesStub = Seeder.GetJsonStubs<Race>("races", SAMPLE_DATA_SOURCES);
            betStub = Seeder.GetJsonStubs<Bet>("bets", SAMPLE_DATA_SOURCES);
            customerStub = Seeder.GetJsonStubs<Customer>("customers", SAMPLE_DATA_SOURCES);

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
