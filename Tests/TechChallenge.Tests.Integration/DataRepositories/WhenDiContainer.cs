﻿using Eml.DataRepository.Contracts;
using Shouldly;
using TechChallenge.Business.Common.Entities;
using TechChallenge.Data.Contracts;
using TechChallenge.Tests.Integration.BaseClasses;
using Xunit;

namespace TechChallenge.Tests.Integration.DataRepositories
{
    public class WhenDiContainer : IntegrationTestDiBase
    {
        //[Theory]
        //[ClassData(typeof(RepositoryClassData))]
        //public void Repository_ShouldBeDiscoverable(Type type)
        //{
        //    var sut = classFactory.Container.GetExportedValueByType(type);

        //    sut.ShouldNotBeNull();
        //}

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
