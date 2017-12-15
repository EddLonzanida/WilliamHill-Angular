using Eml.Contracts.Repositories;
using Shouldly;
using TechChallenge.Business.Common.Entities;
using TechChallenge.Tests.Integration.BaseClasses;
using Xunit;

namespace TechChallenge.Tests.Integration.DataRepositories
{
    public class WhenDiContainer : IntegrationTestBase
    {
        [Fact]
        public void RaceRepository_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<IDataRepositorySoftDeleteInt<Race>>();

            exported.ShouldNotBeNull();
            exported.PageSize.ShouldBe(15);
        }

        [Fact]
        public void BetRepository_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<IDataRepositorySoftDeleteInt<Bet>>();

            exported.ShouldNotBeNull();
            exported.PageSize.ShouldBe(15);
        }

        [Fact]
        public void CustomerRepository_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<IDataRepositorySoftDeleteInt<Customer>>();

            exported.ShouldNotBeNull();
            exported.PageSize.ShouldBe(15);
        }
    }
}
