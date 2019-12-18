using Eml.Contracts.Entities;

namespace TechChallenge.Business.Common.Dto.TechChallengeDb
{
    public class HorseEditCreateRequest : IEntityBase<int>
    {
        public string Name { get; set; }
      
		public int Id { get; set; }
    }
}
