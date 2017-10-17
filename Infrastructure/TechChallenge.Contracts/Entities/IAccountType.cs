namespace TechChallenge.Contracts.Entities
{
    public interface IAccountType : IEntityBase
    {
        string Name { get; set; }
        string Description { get; set; }
    }
}
