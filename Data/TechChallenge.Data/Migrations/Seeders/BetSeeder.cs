using Eml.DataRepository.Extensions;
using System.Data.Entity.Migrations;
using Eml.DataRepository;
using TechChallenge.Business.Common.Entities;

namespace TechChallenge.Data.Migrations.Seeders
{
    public static class BetSeeder
    {
        public static void Seed(TechChallengeDb context, string relativeFolder)
        {
            Seeder.Execute("Bets", () =>
            {
                var intialData = Seeder.GetJsonStubs<Bet>("bets", relativeFolder);

                intialData.ForEach(r => context.Bets.AddOrUpdate(item => item.Id, r));
                context.DoSave("Bet");
            });
        }
    }
}
