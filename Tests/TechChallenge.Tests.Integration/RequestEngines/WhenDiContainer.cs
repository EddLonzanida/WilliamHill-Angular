using Eml.Mediator.Contracts;
using Shouldly;
using TechChallenge.Business.Requests;
using TechChallenge.Business.Responses;
using TechChallenge.Tests.Integration.BaseClasses;
using Xunit;

namespace TechChallenge.Tests.Integration.RequestEngines
{
    public class WhenDiContainer : IntegrationTestDiBase
    {
        [Fact]
        public void CustomerEngine_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<IRequestAsyncEngine<CustomerRequest, CustomerResponse>>();
           
            exported.ShouldNotBeNull();
        }

        [Fact]
        public void RaceStatEngine_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<IRequestAsyncEngine<RaceStatRequest, RaceStatResponse>>();
           
            exported.ShouldNotBeNull();
        }

        [Fact]
        public void RiskCustomerEngine_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<IRequestAsyncEngine<RiskCustomerRequest, RiskCustomerResponse>>();
          
            exported.ShouldNotBeNull();
        }

        [Fact]
        public void TotalBetAmountEngine_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<IRequestAsyncEngine<TotalBetAmountRequest, TotalBetAmountResponse>>();
            
            exported.ShouldNotBeNull();
        }

        [Fact]
        public void TotalBetCountEngine_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<IRequestAsyncEngine<TotalBetCountRequest, TotalBetCountResponse>>();
           
            exported.ShouldNotBeNull();
        }
    }
}
