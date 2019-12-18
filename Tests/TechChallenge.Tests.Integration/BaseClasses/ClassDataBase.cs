using System;
using System.Collections.Generic;
using Xunit;

namespace TechChallenge.Tests.Integration.BaseClasses
{
    public abstract class ClassDataBase<T> : TheoryData<T>
        where T : class
    {
        protected ClassDataBase(Func<List<T>> getTypes)
        {
            var concreteClasses = getTypes();

            concreteClasses.ForEach(Add);
        }
    }
}
