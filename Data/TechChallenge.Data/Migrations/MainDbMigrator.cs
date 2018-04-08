using Eml.ConfigParser;
using Eml.DataRepository;
using Eml.DataRepository.Attributes;
using Eml.DataRepository.BaseClasses;
using System.ComponentModel.Composition;

namespace TechChallenge.Data.Migrations
{
    [DbMigratorExport(Environments.PRODUCTION)]
    public class MainDbMigrator : MigratorBase<TechChallengeDb, Configuration>
    {
        [ImportingConstructor]
        public MainDbMigrator(IConfigBase<string, MainDbConnectionString> mainDbConnectionString)
            : base(mainDbConnectionString.Value)
        {
        }
    }
}
