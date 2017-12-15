using System;
using System.Data.Entity.Migrations;
using TechChallenge.Data.Migrations.Utils;

namespace TechChallenge.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<TechChallengeDb>
    {
        private const string JSON_SOURCES = @"Migrations\JsonSources";

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
           
            CustomerData.Seed(context, JSON_SOURCES);
            RaceData.Seed(context, JSON_SOURCES);
            BetData.Seed(context, JSON_SOURCES);
        }
    }
}
