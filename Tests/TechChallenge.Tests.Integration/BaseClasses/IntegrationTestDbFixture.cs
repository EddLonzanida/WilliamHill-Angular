using Eml.ClassFactory.Contracts;
using Eml.DataRepository.Extensions;
using Eml.Mef;
using System;
using System.Data;
using TechChallenge.Infrastructure;
using Xunit;

namespace TechChallenge.Tests.Integration.BaseClasses
{
    public class IntegrationTestDbFixture : IDisposable
    {
        public const string COLLECTION_DEFINITION = "IntegrationTestDbFixture CollectionDefinition";

        public static IClassFactory ClassFactory { get; private set; }

        public IntegrationTestDbFixture()
        {
            ClassFactory = Bootstrapper.Init("TechChallenge*.dll");

            ConnectionStrings.SetOneTime();
            ApplicationSettings.SetOneTime();

            var dbMigration = ClassFactory.GetMigrator(DbNames.TechChallenge);

            if (dbMigration == null)
            {
                throw new NoNullAllowedException("dbMigration not found..");
            }

            // Exclude SqlServerMigrations files before running this.  Seeders and SqlSeeders are mutually exclusive.
            dbMigration.Execute();
        }

        public void Dispose()
        {
            Eml.Mef.ClassFactory.Dispose(ClassFactory);
        }
    }

    [CollectionDefinition(IntegrationTestDbFixture.COLLECTION_DEFINITION)]
    public class IntegrationTestDbFixtureCollectionDefinition : ICollectionFixture<IntegrationTestDbFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
