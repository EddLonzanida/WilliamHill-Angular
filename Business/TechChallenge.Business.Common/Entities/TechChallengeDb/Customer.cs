using System.Collections.Generic;
using TechChallenge.Business.Common.BaseClasses;
using TechChallenge.Infrastructure.Contracts;

namespace TechChallenge.Business.Common.Entities.TechChallengeDb
{
    public class Customer : EntitySoftDeletableIntBase, ITechChallengeDbEntity
    {
        public string Name { get; set; }

        public virtual List<Bet> Bets { get; set; }
    }
}
