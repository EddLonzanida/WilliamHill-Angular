using System;
using Eml.ClassFactory.Contracts;
using Eml.DataRepository.Attributes;
using Eml.DataRepository.Extensions;
using Eml.Mef;
using Xunit;
using Xunit.Sdk;

namespace TechChallenge.Tests.Integration.BaseClasses
{
    public sealed class IntegrationTestDbFixture : IDisposable
    {
        public const string COLLECTION_DEFINITION = "IntegrationTestDbFixture CollectionDefinition";

        private readonly IMigrator dbMigration;

        public static IClassFactory ClassFactory { get; private set; }

        public IntegrationTestDbFixture()
        {
            Console.WriteLine("Bootstrapper.Init()..");

            ClassFactory = Bootstrapper.Init("TechChallenge*.dll");

            dbMigration = ClassFactory.GetMigrator(Environments.INTEGRATIONTEST);
            if (dbMigration == null)
            {
                throw new NullException("dbMigration not found..");
            }

            Console.WriteLine("DestroyDb if any..");
            dbMigration.DestroyDb();

            Console.WriteLine("CreateDb..");
            dbMigration.CreateDb();
        }

        public void Dispose()
        {
            Console.WriteLine("DisposeDatabase..");

            dbMigration.DestroyDb();

            var container = ClassFactory.Container;

            ClassFactory = null;
            container.Dispose();
        }
    }


    [CollectionDefinition(IntegrationTestDbFixture.COLLECTION_DEFINITION)]
    public class ClassFactoryFixtureCollectionDefinition : ICollectionFixture<IntegrationTestDbFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
