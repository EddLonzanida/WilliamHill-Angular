using Eml.DataRepository.Extensions;
using System.Data.Entity.Migrations;
using Eml.DataRepository;
using TechChallenge.Business.Common.Entities;

namespace TechChallenge.Data.Migrations.Seeders
{
    public static class RaceSeeder
    {
        public static void Seed(TechChallengeDb context, string relativeFolder)
        {
            Seeder.Execute("Races", () =>
            {
                var intialData = Eml.DataRepository.Seed.GetJsonStubs<Race>("races", relativeFolder);

                intialData.ForEach(r => context.Races.AddOrUpdate(item => item.Id, r));
                context.DoSave("Race");
            });
        }
    }
}
