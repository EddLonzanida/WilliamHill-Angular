using System;

namespace TechChallenge.Contracts.Entities
{
    public interface IContract : IEntityBase
    {
        int CompanyId { get; set; }
        string ContractType { get; set; }
        DateTime? DateSigned { get; set; }
        DateTime? EndDate { get; set; }
        DateTime? RenewalDate { get; set; }
        decimal Price { get; set; }
    }
}
