using System;
using System.Collections.Generic;
using System.IO;
using Eml.Contracts.Repositories;
using Eml.Mediator.Contracts;
using Newtonsoft.Json;
using NSubstitute;
using TechChallenge.Business.Common.Entities;

namespace TechChallenge.Tests.Unit.BaseClasses
{
    public abstract class EngineTestBase< T1, T2> : IDisposable
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
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var racesPath = $@"{baseDirectory}\{JSON_SOURCES}\races.json";
            var betsPath = $@"{baseDirectory}\{JSON_SOURCES}\bets.json";
            var customersPath = $@"{baseDirectory}\{JSON_SOURCES}\customers.json";

            racesStub = JsonConvert.DeserializeObject<List<Race>>(File.ReadAllText(racesPath));
            betStub = JsonConvert.DeserializeObject<List<Bet>>(File.ReadAllText(betsPath));
            customerStub = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText(customersPath));

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
