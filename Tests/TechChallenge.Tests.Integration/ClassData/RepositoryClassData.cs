using Eml.DataRepository.Contracts;
using Eml.EntityBaseClasses;
using Eml.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using TechChallenge.Business.Common.Entities;
using Xunit;

namespace TechChallenge.Tests.Integration.ClassData
{
    public class RepositoryClassData : TheoryData<Type>
    {
        private static List<Type> _concreteClasses;

        public RepositoryClassData()
        {
            var dataRepositoryInt = typeof(IDataRepositorySoftDeleteInt<>);

            if (_concreteClasses == null)
            {

                _concreteClasses = typeof(Horse).Assembly
                   .GetClasses(type => !type.IsAbstract
                                       && typeof(EntityBaseInt).IsAssignableFrom(type)
                                       && !type.IsEnum
                                       && type.Namespace != null
                                       && type.Namespace.EndsWith("Entities"))
                   .Select(type =>
                   {
                       Type[] typeArgs = { type };

                       return dataRepositoryInt.MakeGenericType(typeArgs);
                   }).ToList();
            }

            foreach (var type in _concreteClasses)
            {
                Add(type);
            }
        }
    }
}
