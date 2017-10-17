using Eml.ClassFactory.Contracts;
using Xunit;

namespace TechChallenge.Tests.Integration.BaseClasses
{
    [Collection(MefFixture.CLASS_FIXTURE)]
    public abstract class IntegrationTestBase
    {
        protected readonly IClassFactory classFactory;

        protected IntegrationTestBase(MefFixture fixture)
        {
            classFactory = fixture.Factory;
        }
    }
}
