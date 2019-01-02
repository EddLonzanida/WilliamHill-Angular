using System;
using Eml.ClassFactory.Contracts;
using Xunit;
using Eml.Mef;

namespace TechChallenge.Tests.Integration.BaseClasses
{
    public class IntegrationTestDiFixture : IDisposable
    {
        public const string COLLECTION_DEFINITION = "IntegrationTestDiFixture CollectionDefinition";

        public static IClassFactory ClassFactory { get; private set; }

        public IntegrationTestDiFixture()
        {
            ClassFactory = Bootstrapper.Init("TechChallenge*.dll");
        }

        public void Dispose()
        {
            Eml.Mef.ClassFactory.Dispose(ClassFactory);
        }
    }

    [CollectionDefinition(IntegrationTestDiFixture.COLLECTION_DEFINITION)]
    public class IntegrationTestDiFixtureCollectionDefinition : ICollectionFixture<IntegrationTestDiFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
