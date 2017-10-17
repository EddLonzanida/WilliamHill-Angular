
using Eml.Contracts.Entities;

namespace TechChallenge.Contracts.Entities
{
    public interface IEntityBase: IEntityBase<int>, IEntitySoftdeletableBase
    {
    }
}
