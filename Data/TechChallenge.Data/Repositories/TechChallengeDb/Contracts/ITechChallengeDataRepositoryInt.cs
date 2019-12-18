using Eml.Contracts.Entities;
using Eml.DataRepository.MsSql.Contracts;
using TechChallenge.Infrastructure.Contracts;

namespace TechChallenge.Data.Repositories.TechChallengeDb.Contracts
{
    public interface ITechChallengeDataRepositoryInt<T> : IDataRepositoryMsSqlInt<T, Data.TechChallengeDb>
        where T : class, IEntityBase<int>, ITechChallengeDbEntity
    {
    }
}
