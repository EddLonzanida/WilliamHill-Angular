using System.Data.Entity.Migrations;
using TechChallenge.Data;

namespace TechChallenge.DataMigration
{
    public sealed class MigrationConfiguration : DbMigrationsConfiguration<TechChallengeDb>
    {
        public MigrationConfiguration()
        {
            var isEnabled = false; //Disable if running in Release Mode
#if DEBUG
            isEnabled = true;
#endif
            AutomaticMigrationsEnabled = isEnabled;
            AutomaticMigrationDataLossAllowed = isEnabled;

            MigrationsDirectory = "SqlServerMigrations";
            MigrationsNamespace = "TechChallenge.DataMigration.SqlServerMigrations";
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
