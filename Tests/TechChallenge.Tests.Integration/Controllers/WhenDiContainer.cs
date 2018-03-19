using Shouldly;
using TechChallenge.ApiHost.Api.Amounts;
using TechChallenge.ApiHost.Api.Customers;
using TechChallenge.ApiHost.Api.Dashboard;
using TechChallenge.Tests.Integration.BaseClasses;
using Xunit;

namespace TechChallenge.Tests.Integration.Controllers
{
    public class WhenDiContainer : IntegrationTestDiBase
    {
        [Fact]
        public void AmountsController_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<AmountsController>();

            exported.ShouldNotBeNull();
        }

        [Fact]
        public void CustomersController_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<CustomersController>();

            exported.ShouldNotBeNull();
        }

        [Fact]
        public void DashboardController_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<DashboardController>();

            exported.ShouldNotBeNull();
        }
    }
}
