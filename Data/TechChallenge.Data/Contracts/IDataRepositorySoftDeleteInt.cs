using Eml.Contracts.Entities;
using Eml.DataRepository.Contracts;

namespace TechChallenge.Data.Contracts
{
    public interface IDataRepositorySoftDeleteInt<T> : IDataRepositorySoftDeleteInt<T, TechChallengeDb>
        where T : class, IEntityBase<int>, IEntitySoftdeletableBase
    {
    }
}
