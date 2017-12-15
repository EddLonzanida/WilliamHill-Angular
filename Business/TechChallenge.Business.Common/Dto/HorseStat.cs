using Eml.Contracts.Entities;

namespace TechChallenge.Business.Common.Dto
{
    public class HorseStat : IEntityBase<int>
    {
        public int Id { get; set; }

        public int RaceId { get; set; }

        public string Name { get; set; }

        public double Odds { get; set; }

        public int BetCount { get; set; }

        public double WinAmount { get; set; } //Stake * Odds
    }
}
