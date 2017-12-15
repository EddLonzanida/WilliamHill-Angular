using System.Collections.Generic;
using Eml.Mediator.Contracts;
using TechChallenge.Business.Common.Dto;

namespace TechChallenge.Business.Responses
{
    public class RaceStatResponse : IResponse
    {
        public IEnumerable<RaceStat> RaceStats { get; }

        public RaceStatResponse(IEnumerable<RaceStat> raceStats)
        {
            RaceStats = raceStats;
        }
    }
}
