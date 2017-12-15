using Eml.ClassFactory.Contracts;
using Eml.Mediator.Contracts;
using Eml.Mef;
using Xunit;

namespace TechChallenge.Tests.Integration.BaseClasses
{
    [Collection(MefFixture.COLLECTION_DEFINITION)]
    public abstract class IntegrationTestBase
    {
        protected readonly IClassFactory classFactory;

        protected readonly IMediator mediator;

        protected IntegrationTestBase()
        {
            classFactory = ClassFactory.Get();
            mediator = classFactory.GetExport<IMediator>();
        }
    }
}
