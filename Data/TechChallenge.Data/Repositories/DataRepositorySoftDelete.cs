using Eml.Contracts.Entities;
using Eml.DataRepository;
using System.ComponentModel.Composition;
using TechChallenge.Data.Contracts;

namespace TechChallenge.Data.Repositories
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IDataRepositorySoftDeleteInt<>))]
    public class DataRepositorySoftDeleteInt<T> : DataRepositorySoftDeleteInt<T, TechChallengeDb>, IDataRepositorySoftDeleteInt<T>
        where T : class, IEntityBase<int>, IEntitySoftdeletableBase
    {
    }
}
