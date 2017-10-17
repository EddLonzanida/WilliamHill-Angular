using Eml.Contracts.Entities;

namespace TechChallenge.Business.Common.Dto
{
    public class CustomerBetCount : IEntityBase<int>
    {
        public int Id { get; set; }
        public double TotalBets { get; set; }
    }
}
