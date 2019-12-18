using TechChallenge.Business.Common.Entities.TechChallengeDb;

namespace TechChallenge.Business.Common.Dto.TechChallengeDb.EntityHelpers
{
    public static class CustomerExtensions
    {
        public static Customer ToEntity(this CustomerEditCreateRequest dto)
        {
            return new Customer
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }

        public static CustomerDetailsCreateResponse ToDto(this Customer entity)
        {
            return new CustomerDetailsCreateResponse
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
