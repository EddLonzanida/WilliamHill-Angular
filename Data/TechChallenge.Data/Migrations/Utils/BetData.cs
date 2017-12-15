using Eml.DataRepository.Extensions;
using System.Data.Entity.Migrations;
using TechChallenge.Business.Common.Entities;

namespace TechChallenge.Data.Migrations.Utils
{
    public static class BetData
    {
        public static void Seed(TechChallengeDb context, string relativeFolder)
        {
            var intialData = Eml.DataRepository.Seed.GetStubs<Bet>("bets", relativeFolder);
            intialData.ForEach(r =>
            {
                context.Bets.AddOrUpdate(item => item.Id, r);
            });
            context.DoSave("Bet");
        }
    }
}
