using Shouldly;
using TechChallenge.Business.Common.Entities.TechChallengeDb;
using TechChallenge.Data.Repositories.TechChallengeDb.Contracts;
using TechChallenge.Tests.Integration.BaseClasses;
using Xunit;

namespace TechChallenge.Tests.Integration.DataRepositories
{
    public class WhenDiContainer : IntegrationTestDbBase
    {
        //[Theory]
        //[ClassData(typeof(RepositoryClassData))]
        //public void Repositories_ShouldBeDiscoverable(Type type)
        //{
        //    var sut = classFactory.Container.GetExportedValueByType(type);

        //    sut.ShouldNotBeNull();
        //}

        [Fact]
        public void RaceRepository_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<ITechChallengeDataRepositorySoftDeleteInt<Race>>();

            exported.ShouldNotBeNull();
            exported.GetPageSize().ShouldBe(15);
        }

        [Fact]
        public void BetRepository_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<ITechChallengeDataRepositorySoftDeleteInt<Bet>>();

            exported.ShouldNotBeNull();
            exported.GetPageSize().ShouldBe(15);
        }

        [Fact]
        public void CustomerRepository_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<ITechChallengeDataRepositorySoftDeleteInt<Customer>>();

            exported.ShouldNotBeNull();
            exported.GetPageSize().ShouldBe(15);
        }

        [Fact]
        public void HorseRepository_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<ITechChallengeDataRepositorySoftDeleteInt<Horse>>();

            exported.ShouldNotBeNull();
            exported.GetPageSize().ShouldBe(15);
        }

    }
}
