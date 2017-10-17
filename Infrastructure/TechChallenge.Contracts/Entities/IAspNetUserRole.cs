namespace TechChallenge.Contracts.Entities
{
    public interface IAspNetUserRole : IEntityBase
    {
         string UserName { get; set; }

         string Email { get; set; }

         string Role { get; set; }

         string OldRole { get; set; }
    }
}
