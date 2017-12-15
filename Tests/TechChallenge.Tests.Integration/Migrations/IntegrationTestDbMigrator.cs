using System.ComponentModel.Composition;
using Eml.ConfigParser;
using Eml.DataRepository;
using Eml.DataRepository.Attributes;
using Eml.DataRepository.BaseClasses;
using TechChallenge.Data;

namespace TechChallenge.Tests.Integration.Migrations
{
    [DbMigratorExport(Environments.INTEGRATIONTEST)]
    public class IntegrationTestDbMigration : MigratorBase<TechChallengeDb, IntegrationTestConfiguration>
    {
        [ImportingConstructor]
        public IntegrationTestDbMigration(IConfigBase<string, MainDbConnectionString> mainDbConnectionString)
            : base(mainDbConnectionString.Value, true)
        {
        }
    }
}
