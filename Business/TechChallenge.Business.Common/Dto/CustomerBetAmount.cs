using Eml.Contracts.Entities;

namespace TechChallenge.Business.Common.Dto
{
    public class CustomerBetAmount : IEntityBase<int>
    {
        public int Id { get; set; }

        public double Totalstake { get; set; }
    }
}
