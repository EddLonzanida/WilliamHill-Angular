using System;

namespace TechChallenge.Business.Common.BaseClasses
{
    public abstract class RaceBase : EntityBase
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime Start { get; set; }
    }
}
