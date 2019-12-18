using TechChallenge.Business.Common.Entities.TechChallengeDb;

namespace TechChallenge.Business.Common.Dto.TechChallengeDb.EntityHelpers
{
    public static class HorseExtensions
    {
        public static Horse ToEntity(this HorseEditCreateRequest dto)
        {
            return new Horse
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }

        public static HorseDetailsCreateResponse ToDto(this Horse entity)
        {
            return new HorseDetailsCreateResponse
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
