using Eml.DataRepository;
using Eml.DataRepository.Extensions;
using Eml.Extensions;
using System.Data.Entity.Migrations;
using TechChallenge.Business.Common.Entities.TechChallengeDb;
using TechChallenge.Data;

namespace TechChallenge.DataMigration.Seeders
{
    public static class BetSeeder
    {
        public static void Seed<T>(T context, string relativeFolder)
            where T : TechChallengeDb
        {
#if DEBUG
            var entityName = typeof(Bet).Name.Pluralize();

            Seeder.Execute(entityName, () =>
            {
                var initialData = Seeder.GetJsonStubs<Bet>(entityName.ToLower(), relativeFolder);

                initialData.ForEach(r => context.Bets.AddOrUpdate(item => item.Id, r));
                context.DoSave(entityName);
            });
#endif
        }
    }
}
