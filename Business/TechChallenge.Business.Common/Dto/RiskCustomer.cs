using System.Collections.Generic;
using Eml.Contracts.Entities;
using TechChallenge.Business.Common.Entities.TechChallengeDb;

namespace TechChallenge.Business.Common.Dto
{
    public class RiskCustomer : IEntityBase<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Bet> Bets { get; set; }
    }
}
