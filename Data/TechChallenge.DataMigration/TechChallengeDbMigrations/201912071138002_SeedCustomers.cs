using Eml.DataRepository;
using System;
using System.Data.Entity.Migrations;
using TechChallenge.Business.Common.Entities.TechChallengeDb;

namespace TechChallenge.DataMigration.TechChallengeDbMigrations
{
    public partial class SeedCustomers : DbMigration
    {
        private const string ID_COLUMN = "Id";
        private const string COLUMNS = "Id,[Name]";
        private const string SAMPLE_DATA = "SampleDataSources";

        private readonly string tableName;

        public SeedCustomers()
        {
            tableName = GetType().Name.Replace("Seed", string.Empty);
        }

        public override void Up()
        {
            var initialData = Seeder.GetJsonStubs<Customer>(tableName.ToLower(), SAMPLE_DATA);

            var data = initialData.ConvertAll(r => $" INSERT INTO {tableName} ({COLUMNS}) VALUES ({r.Id}, '{r.Name}')");

            data.Insert(0, $" SET IDENTITY_INSERT {tableName} ON;");
            data.Add($" SET IDENTITY_INSERT {tableName} OFF;");

            var sql = string.Join(Environment.NewLine, data.ToArray());

            Sql(sql);
        }

        public override void Down()
        {
            Sql($@"DELETE FROM {tableName} WHERE {ID_COLUMN} BETWEEN 1 AND 13");
        }
    }
}