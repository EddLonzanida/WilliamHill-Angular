using Eml.ConfigParser;
using Eml.DataRepository;
using Eml.DataRepository.Attributes;
using Eml.DataRepository.BaseClasses;
using System.ComponentModel.Composition;
using TechChallenge.Data;

namespace TechChallenge.DataMigration
{
    [DbMigratorExport(Environments.PRODUCTION)]
    public class MainDbMigrator : MigratorBase<TechChallengeDb, MigrationConfiguration>
    {
        [ImportingConstructor]
        public MainDbMigrator(IConfigBase<string, MainDbConnectionString> mainDbConnectionString)
            : base(mainDbConnectionString.Value)
        {
        }
    }
}
