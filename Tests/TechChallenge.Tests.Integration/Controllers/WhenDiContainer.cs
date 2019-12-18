using Eml.Extensions;
using Shouldly;
using System;
using System.ComponentModel.Composition;
using Eml.MefExtensions;
using TechChallenge.Tests.Integration.BaseClasses;
using TechChallenge.Tests.Integration.ClassData;
using Xunit;

namespace TechChallenge.Tests.Integration.Controllers
{
    public class WhenDiContainer : IntegrationTestDbBase
    {
        [Theory]
        [ClassData(typeof(ControllerClassData))]
        public void Controller_ShouldBeExportable(Type type)
        {
            var sut = classFactory.Container.GetExportedValueByType(type);

            sut.ShouldNotBeNull();
        }

        [Theory]
        [ClassData(typeof(ControllerClassData))]
        public void Controller_ShouldHaveExportAttributes(Type type)
        {
            var sut = type.GetClassAttribute<ExportAttribute>();

            sut.ShouldNotBeNull();
        }
    }
}
