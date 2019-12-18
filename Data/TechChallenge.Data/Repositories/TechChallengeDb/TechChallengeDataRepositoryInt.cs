using Eml.Contracts.Entities;
using TechChallenge.Data.Repositories.TechChallengeDb.BaseClasses;
using TechChallenge.Data.Repositories.TechChallengeDb.Contracts;
using TechChallenge.Infrastructure.Contracts;
using System.ComponentModel.Composition;

namespace TechChallenge.Data.Repositories.TechChallengeDb
{
    [Export(typeof(ITechChallengeDataRepositoryInt<>))]
    public class TechChallengeDataRepositoryInt<T> : TechChallengeDataRepositoryBase<int, T>, ITechChallengeDataRepositoryInt<T>
        where T : class, IEntityBase<int>, ITechChallengeDbEntity
    {
    }
}
