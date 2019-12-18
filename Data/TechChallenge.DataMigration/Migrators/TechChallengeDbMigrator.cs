using Eml.DataRepository.Attributes;
using Eml.DataRepository.BaseClasses;
using TechChallenge.Infrastructure;

namespace TechChallenge.DataMigration.Migrators
{
    [DbMigratorExport(DbNames.TechChallenge)]
    public class TechChallengeDbMigrator : MigratorBase<TechChallengeDb, TechChallengeDbMigrationConfiguration>
    {
    }
}

