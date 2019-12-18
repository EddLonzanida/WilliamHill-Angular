using System.Data.Entity.Migrations;

namespace TechChallenge.DataMigration.Migrators
{
    public sealed class TechChallengeDbMigrationConfiguration : DbMigrationsConfiguration<TechChallengeDb>
    {
        public TechChallengeDbMigrationConfiguration()
        {
#if DEBUG
            const bool isEnabled = true; //Disabled if running in Release Mode

            AutomaticMigrationsEnabled = isEnabled;
            AutomaticMigrationDataLossAllowed = isEnabled;
#endif

            MigrationsDirectory = "TechChallengeDbMigrations";
            MigrationsNamespace = "TechChallenge.DataMigration.TechChallengeDbMigrations";
        }

        protected override void Seed(TechChallengeDb context)
        {
        }
    }
}


//Add-Migration InitialCreate
//Update-Database -verbose

//Add-Migration SeedRaces
//Update-Database -verbose

//Add-Migration SeedHorses
//Update-Database -verbose

//Add-Migration SeedCustomers
//Update-Database -verbose

//Add-Migration SeedBets
//Update-Database -verbose
