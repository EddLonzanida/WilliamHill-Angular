using System;
using System.Collections.Generic;
using Eml.EntityBaseClasses;

namespace TechChallenge.Business.Common.Entities
{
    public class Race : EntityBaseSoftDeleteInt
    {
        public string Name { get; set; }

        public string Status { get; set; }

        public DateTime Start { get; set; }

        public virtual List<Horse> Horses { get; set; }

        public virtual List<Bet> Bets { get; set; }
    }
}
