using System;
using System.Web.Http;
using Eml.Mediator.Contracts;
using NSubstitute;
using TechChallenge.Business.Responses;

namespace TechChallenge.Tests.Unit.BaseClasses
{
    public abstract class ControllerTestBase<T> : IDisposable
        where T : ApiController
    {
        private const string SAMPLE_DATA_SOURCES = @"SampleDataSources";

        protected readonly IMediator mediator;

        protected readonly TotalBetAmountResponse totalBetAmountResponseStub;

        protected T controller;

        protected ControllerTestBase()
        {
            totalBetAmountResponseStub = Eml.DataRepository.Seed.GetJsonStub<TotalBetAmountResponse>("TotalBetAmountResponse", SAMPLE_DATA_SOURCES);

            mediator = Substitute.For<IMediator>();
        }

        public void Dispose()
        {
            controller?.Dispose();
        }
    }
}
