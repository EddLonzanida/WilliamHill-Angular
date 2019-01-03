using System.Collections.Generic;
using Eml.EntityBaseClasses;

namespace TechChallenge.Business.Common.Entities
{
    public class Customer : EntityBaseSoftDeleteInt
    {
        public string Name { get; set; }

        public virtual List<Bet> Bets { get; set; }
    }
}
