using System.Data.Entity.Migrations;
using Eml.DataRepository;
using Eml.DataRepository.Extensions;
using Eml.Extensions;
using TechChallenge.Data;
using TechChallenge.Business.Common.Entities;

namespace TechChallenge.DataMigration.Seeders
{
    public static class RaceSeeder
    {
        public static void Seed<T>(T context, string relativeFolder)
            where T : TechChallengeDb
        {
#if DEBUG
            var entityName = typeof(Race).Name.Pluralize();

            Seeder.Execute(entityName, () =>
            {
                var initialData = Seeder.GetJsonStubs<Race>(entityName.ToLower(), relativeFolder);

                initialData.ForEach(r => context.Races.AddOrUpdate(item => item.Id, r));

                context.DoSave(entityName);
            });
#endif
        }
    }
}
