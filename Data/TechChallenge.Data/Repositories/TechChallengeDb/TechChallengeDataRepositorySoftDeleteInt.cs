using Eml.Contracts.Entities;
using TechChallenge.Data.Repositories.TechChallengeDb.BaseClasses;
using TechChallenge.Data.Repositories.TechChallengeDb.Contracts;
using TechChallenge.Infrastructure.Contracts;
using System.ComponentModel.Composition;

namespace TechChallenge.Data.Repositories.TechChallengeDb
{
    [Export(typeof(ITechChallengeDataRepositorySoftDeleteInt<>))]
    public class TechChallengeDataRepositorySoftDeleteInt<T> : TechChallengeDataRepositorySoftDeleteBase<int, T>, ITechChallengeDataRepositorySoftDeleteInt<T>
        where T : class, IEntityBase<int>, IEntitySoftdeletableBase, ITechChallengeDbEntity
    {
    }
}
