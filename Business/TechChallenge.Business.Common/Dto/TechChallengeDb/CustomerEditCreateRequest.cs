using Eml.Contracts.Entities;

namespace TechChallenge.Business.Common.Dto.TechChallengeDb
{
    public class CustomerEditCreateRequest : IEntityBase<int>
    {
        public string Name { get; set; }
      
		public int Id { get; set; }
    }
}
