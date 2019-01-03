using System.ComponentModel.Composition;
using Eml.Contracts.Entities;
using Eml.DataRepository;

namespace TechChallenge.Data.Repositories
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DataRepositorySoftDelete<T> : DataRepositorySoftDeleteInt<T, TechChallengeDb>
        where T : class, IEntityBase<int>, IEntitySoftdeletableBase     //Do not use IEntityBase from TechChallenge.Contracts.Entities. Although they are practically identical, MEF was unable to detect IEntityBase.
    {
    }
}
