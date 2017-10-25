using System;
using System.IO;
using System.Web.Http;
using Eml.Mediator.Contracts;
using Newtonsoft.Json;
using NSubstitute;
using TechChallenge.Business.Responses;

namespace TechChallenge.Tests.Unit.BaseClasses
{
    public abstract class ControllerTestBase<T> : IDisposable
        where T : ApiController
    {
        private const string JSON_SOURCES = @"SampleData";
        protected readonly IMediator mediator;
        protected readonly TotalBetAmountResponse totalBetAmountResponseStub;
        protected T controller;

        protected ControllerTestBase()
        {
            var betsPath = $@"{AppDomain.CurrentDomain.BaseDirectory}\{JSON_SOURCES}\TotalBetAmountResponse.json";
            totalBetAmountResponseStub = JsonConvert.DeserializeObject<TotalBetAmountResponse>(File.ReadAllText(betsPath));
            mediator = Substitute.For<IMediator>();
        }

        public void Dispose()
        {
            controller?.Dispose();
        }
    }
}
