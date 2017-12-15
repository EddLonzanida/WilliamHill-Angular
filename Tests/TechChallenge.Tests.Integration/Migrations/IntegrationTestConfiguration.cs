using System;
using System.Data.Entity.Migrations;
using TechChallenge.Data;
using TechChallenge.Data.Migrations.Utils;

namespace TechChallenge.Tests.Integration.Migrations
{
    public class IntegrationTestConfiguration: DbMigrationsConfiguration<TechChallengeDb>
    {
        private const string JSON_SOURCES = @"Migrations\JsonSources";

        public IntegrationTestConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TechChallengeDb context)
        {
            Console.WriteLine("Seeding Data..");

            CustomerData.Seed(context, JSON_SOURCES);
            RaceData.Seed(context, JSON_SOURCES);
            BetData.Seed(context, JSON_SOURCES);
        }
    }
}
