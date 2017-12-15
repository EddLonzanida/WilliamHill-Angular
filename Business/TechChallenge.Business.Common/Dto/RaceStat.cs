using System;
using System.Collections.Generic;
using Eml.Contracts.Entities;

namespace TechChallenge.Business.Common.Dto
{
    public class RaceStat : IEntityBase<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public DateTime Start { get; set; }

        public double RaceTotalAmount { get; set; }

        public List<HorseStat> HorseStats { get; set; } = new List<HorseStat>();
    }
}
