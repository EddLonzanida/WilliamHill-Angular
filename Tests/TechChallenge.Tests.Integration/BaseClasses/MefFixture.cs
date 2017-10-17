using System;
using Eml.ClassFactory.Contracts;
using Eml.Mef;
using Xunit;

namespace TechChallenge.Tests.Integration.BaseClasses
{
    public class MefFixture : IDisposable
    {
        public const string CLASS_FIXTURE = "ClassFactory CollectionDefinition";

        public IClassFactory Factory { get; }
        public MefFixture()
        {
            Bootstrapper.Init(AppDomain.CurrentDomain.BaseDirectory, new[] { "TechChallenge*.dll" });
            Factory = ClassFactory.MefContainer.GetExportedValue<IClassFactory>();
        }

        public void Dispose()
        {
            Factory.Container?.Dispose();
        }
    }


    [CollectionDefinition(MefFixture.CLASS_FIXTURE)]
    public class ClassFactoryFixtureCollectionDefinition : ICollectionFixture<MefFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
