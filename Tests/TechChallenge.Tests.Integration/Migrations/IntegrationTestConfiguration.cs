using System;
using System.Data.Entity.Migrations;
using TechChallenge.Data;
using TechChallenge.Data.Migrations.Seeders;

namespace TechChallenge.Tests.Integration.Migrations
{
    public class IntegrationTestConfiguration: DbMigrationsConfiguration<TechChallengeDb>
    {
        private const string SAMPLE_DATA_SOURCES = @"Migrations\SampleDataSources";

        public IntegrationTestConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TechChallengeDb context)
        {
            Console.WriteLine("Seeding Data..");

            CustomerSeeder.Seed(context, SAMPLE_DATA_SOURCES);
            RaceSeeder.Seed(context, SAMPLE_DATA_SOURCES);
            BetSeeder.Seed(context, SAMPLE_DATA_SOURCES);
        }
    }
}
