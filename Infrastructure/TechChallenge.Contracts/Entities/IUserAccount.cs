using System.Collections.Generic;

namespace TechChallenge.Contracts.Entities
{
    public interface IUserAccount : IEntityBase
    {
        string UserName { get; set; }
        string LoginEmail { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string State { get; set; }
        string ZipCode { get; set; }
        string CreditCard { get; set; }
        string ExpDate { get; set; }
        IEnumerable<string> Roles { get; set; }
        bool HasRole { get; }
    }
}
