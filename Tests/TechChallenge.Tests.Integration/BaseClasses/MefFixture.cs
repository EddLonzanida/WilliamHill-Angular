using System;
using Eml.DataRepository.Attributes;
using Eml.DataRepository.Extensions;
using Eml.Mef;
using Xunit;
using Xunit.Sdk;

namespace TechChallenge.Tests.Integration.BaseClasses
{
    public sealed class MefFixture : IDisposable
    {
        public const string COLLECTION_DEFINITION = "MefFixture CollectionDefinition";

        private readonly IMigrator dbMigration;

        public MefFixture()
        {
            Console.WriteLine("Bootstrapper.Init()..");

            Bootstrapper.Init("TechChallenge*.dll");
            var classFactory = ClassFactory.Get();

            dbMigration = classFactory.GetMigrator(Environments.INTEGRATIONTEST);
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

            ClassFactory.Dispose();
        }
    }


    [CollectionDefinition(MefFixture.COLLECTION_DEFINITION)]
    public class ClassFactoryFixtureCollectionDefinition : ICollectionFixture<MefFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
