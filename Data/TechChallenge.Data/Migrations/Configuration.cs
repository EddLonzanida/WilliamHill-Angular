using System;
using System.Data.Entity.Migrations;
using TechChallenge.Data.Migrations.Seeders;

namespace TechChallenge.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<TechChallengeDb>
    {
        private const string SAMPLE_DATA_SOURCES = @"Migrations\SampleDataSources";

        public Configuration()
        {
            var isEnabled = false; //Disable if running in Release Mode
#if DEBUG
            isEnabled = true;
#endif
            AutomaticMigrationsEnabled = isEnabled;
            AutomaticMigrationDataLossAllowed = isEnabled;
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
