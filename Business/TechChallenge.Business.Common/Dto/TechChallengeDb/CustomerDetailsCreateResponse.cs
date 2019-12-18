using System.Collections.Generic;
using TechChallenge.Business.Common.BaseClasses;
using TechChallenge.Business.Common.Entities.TechChallengeDb;

namespace TechChallenge.Business.Common.Dto.TechChallengeDb
{
    public class CustomerDetailsCreateResponse : EntityIntBase
    {
        public string Name { get; set; }

        public virtual List<Bet> Bets { get; set; }
    }
}
