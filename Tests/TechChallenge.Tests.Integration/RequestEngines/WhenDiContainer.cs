using Eml.Mediator.Contracts;
using Shouldly;
using TechChallenge.Business.Common.Requests;
using TechChallenge.Business.Common.Responses;
using TechChallenge.Tests.Integration.BaseClasses;
using Xunit;

namespace TechChallenge.Tests.Integration.RequestEngines
{
    public class WhenDiContainer : IntegrationTestDiBase
    {
        [Fact]
        public void CustomerEngine_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<IRequestAsyncEngine<CustomerAsyncRequest, CustomerResponse>>();

            exported.ShouldNotBeNull();
        }

        [Fact]
        public void RaceStatEngine_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<IRequestAsyncEngine<RaceStatAsyncRequest, RaceStatResponse>>();

            exported.ShouldNotBeNull();
        }

        [Fact]
        public void RiskCustomerEngine_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<IRequestAsyncEngine<RiskCustomerAsyncRequest, RiskCustomerResponse>>();

            exported.ShouldNotBeNull();
        }

        [Fact]
        public void TotalBetAmountEngine_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<IRequestAsyncEngine<TotalBetAmountAsyncRequest, TotalBetAmountResponse>>();

            exported.ShouldNotBeNull();
        }

        [Fact]
        public void TotalBetCountEngine_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<IRequestAsyncEngine<TotalBetCountAsyncRequest, TotalBetCountResponse>>();

            exported.ShouldNotBeNull();
        }
    }
}
