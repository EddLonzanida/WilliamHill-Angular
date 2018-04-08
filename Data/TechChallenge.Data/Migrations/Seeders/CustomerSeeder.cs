using Eml.DataRepository.Extensions;
using System.Data.Entity.Migrations;
using Eml.DataRepository;
using TechChallenge.Business.Common.Entities;

namespace TechChallenge.Data.Migrations.Seeders
{
    public static class CustomerSeeder
    {
        public static void Seed(TechChallengeDb context, string relativeFolder)
        {
            Seeder.Execute("Customers", () =>
            {
                var intialData = Eml.DataRepository.Seed.GetJsonStubs<Customer>("customers", relativeFolder);

                intialData.ForEach(r => context.Customers.AddOrUpdate(item => item.Id, r));
                context.DoSave("Customer");
            });
        }
    }
}
