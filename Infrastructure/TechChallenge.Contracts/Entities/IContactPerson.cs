namespace TechChallenge.Contracts.Entities
{
    public interface IContactPerson : IEntityBase
    {
        int CompanyId { get; set; }

        int PositionTitleId { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string ContractType { get; set; }

        string Email { get; set; }

        string PhoneNumber { get; set; }

        string Department { get; set; }

        bool IsActive { get; set; }
    }
}