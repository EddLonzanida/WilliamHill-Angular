using Eml.DataRepository.Extensions;
using System.Data.Entity.Migrations;
using TechChallenge.Business.Common.Entities;

namespace TechChallenge.Data.Migrations.Utils
{
    public static class RaceData
    {
        public static void Seed(TechChallengeDb context, string relativeFolder)
        {
            var intialData = Eml.DataRepository.Seed.GetStubs<Race>("races", relativeFolder);
            intialData.ForEach(r =>
            {
                context.Races.AddOrUpdate(item => item.Id, r);
            });
            context.DoSave("Race");
        }
    }
}
