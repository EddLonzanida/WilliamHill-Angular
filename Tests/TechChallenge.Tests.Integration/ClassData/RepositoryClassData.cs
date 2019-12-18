using Eml.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using TechChallenge.Business.Common.BaseClasses;
using TechChallenge.Data.Repositories.TechChallengeDb.Contracts;
using TechChallenge.Infrastructure.Contracts;
using TechChallenge.Tests.Integration.BaseClasses;

namespace TechChallenge.Tests.Integration.ClassData
{
    public class RepositoryClassData : ClassDataBase<Type>
    {
        private static List<Type> _repositories;

        public RepositoryClassData()
            : base(() =>
            {
                var dataRepositoryInt = typeof(ITechChallengeDataRepositorySoftDeleteInt<>);

                return _repositories ?? (_repositories = typeof(EntitySoftDeletableIntBase).Assembly
                           .GetClasses(type => typeof(ITechChallengeDbEntity).IsAssignableFrom(type)
                                               && !type.IsAbstract
                                               && !type.IsEnum
                                               && type.Namespace != null
                                               && type.Namespace.Contains("Business.Common.Entities"))
                           .Select(type =>
                           {
                               Type[] typeArgs = { type };

                               return dataRepositoryInt.MakeGenericType(typeArgs);
                           })
                           .ToList());
            })
        { }
    }
}
