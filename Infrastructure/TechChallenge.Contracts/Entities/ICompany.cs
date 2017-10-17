namespace TechChallenge.Contracts.Entities
{
    public interface ICompany : IEntityBase
    {
        string Name { get; set; }
        string Description { get; set; }
        string Website { get; set; }
        string AbnCan  { get; set; }
    }
}
