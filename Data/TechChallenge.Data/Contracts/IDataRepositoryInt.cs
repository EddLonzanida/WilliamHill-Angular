using Eml.Contracts.Entities;
using Eml.DataRepository.Contracts;

namespace TechChallenge.Data.Contracts
{
    public interface IDataRepositoryInt<T> : IDataRepositoryInt<T, TechChallengeDb>
        where T : class, IEntityBase<int>
    {
    }
}
