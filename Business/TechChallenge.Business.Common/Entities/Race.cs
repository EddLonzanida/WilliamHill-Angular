using System;
using System.Collections.Generic;
using TechChallenge.Business.Common.BaseClasses;

namespace TechChallenge.Business.Common.Entities
{
    public class Race : EntityBase
    {
        public string Name { get; set; }

        public string Status { get; set; }

        public DateTime Start { get; set; }

        public virtual List<Horse> Horses { get; set; }
    }
}
