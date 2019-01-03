using Eml.Extensions;
using System;
using System.Collections.Generic;
using System.Web.Http;
using TechChallenge.Api;
using Xunit;

namespace TechChallenge.Tests.Integration.ClassData
{
    public class ControllerClassData : TheoryData<Type>
    {
        private static List<Type> _concreteClasses;

        public ControllerClassData()
        {
            if (_concreteClasses == null)
            {
                _concreteClasses = typeof(WebApiApplication).Assembly
                    .GetClasses(type => !type.IsAbstract && typeof(ApiController).IsAssignableFrom(type));
            }

            foreach (var type in _concreteClasses)
            {
                Add(type);
            }
        }
    }
}
