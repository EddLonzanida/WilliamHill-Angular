using Eml.DataRepository.Extensions;
using System.Data.Entity.Migrations;
using TechChallenge.Business.Common.Entities;

namespace TechChallenge.Data.Migrations.Utils
{
    public static class CustomerData
    {
        public static void Seed(TechChallengeDb context, string relativeFolder)
        {
            var intialData = Eml.DataRepository.Seed.GetStubs<Customer>("customers", relativeFolder);

            intialData.ForEach(r =>
            {
                context.Customers.AddOrUpdate(item => item.Id, r);
            });
            context.DoSave("Customer");
        }
    }
}
