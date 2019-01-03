using System.Data.Entity.Migrations;
using Eml.DataRepository;
using Eml.DataRepository.Extensions;
using Eml.Extensions;
using TechChallenge.Data;
using TechChallenge.Business.Common.Entities;

namespace TechChallenge.DataMigration.Seeders
{
    public static class CustomerSeeder
    {
        public static void Seed<T>(T context, string relativeFolder)
            where T : TechChallengeDb
        {
#if DEBUG
            var entityName = typeof(Customer).Name.Pluralize();

            Seeder.Execute(entityName, () =>
            {
                var initialData = Seeder.GetJsonStubs<Customer>(entityName.ToLower(), relativeFolder);

                initialData.ForEach(r => context.Customers.AddOrUpdate(item => item.Id, r));
                context.DoSave(entityName);
            });
#endif
        }
    }
}
