using Eml.Contracts.Entities;

namespace TechChallenge.Business.Common.BaseClasses
{
    public abstract class EntityIntBase : IEntityBase<int>
    {
        public int Id { get; set; }
    }
}