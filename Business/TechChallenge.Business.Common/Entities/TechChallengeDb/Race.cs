using System;
using System.Collections.Generic;
using TechChallenge.Business.Common.BaseClasses;
using TechChallenge.Infrastructure.Contracts;

namespace TechChallenge.Business.Common.Entities.TechChallengeDb
{
    public class Race : EntitySoftDeletableIntBase, ITechChallengeDbEntity
    {
        public string Name { get; set; }

        public string Status { get; set; }

        public DateTime Start { get; set; }

        public virtual List<Horse> Horses { get; set; }

        public virtual List<Bet> Bets { get; set; }
    }
}
