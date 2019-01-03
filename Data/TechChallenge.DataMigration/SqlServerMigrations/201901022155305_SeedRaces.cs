using Eml.DataRepository;
using System;
using System.Data.Entity.Migrations;
using TechChallenge.Business.Common.Entities;

namespace TechChallenge.DataMigration.SqlServerMigrations
{
    public partial class SeedRaces : DbMigration
    {
        private const string ID_COLUMN = "Id";
        private const string COLUMNS = "Id, [Name], [Status], [Start]";
        private const string SAMPLE_DATA = "SampleDataSources";

        private readonly string tableName;

        public SeedRaces()
        {
            tableName = GetType().Name.Replace("Seed", string.Empty);
        }

        private static string GetDate(DateTime dt)
        {
            return dt.ToString("s");
        }

        public override void Up()
        {
            var initialData = Seeder.GetJsonStubs<Race>(tableName.ToLower(), SAMPLE_DATA);

            var data = initialData.ConvertAll(r => $" INSERT INTO {tableName} ({COLUMNS}) VALUES ({r.Id}, '{r.Name}', '{r.Status}', '{GetDate(r.Start)}')");

            data.Insert(0, $" SET IDENTITY_INSERT {tableName} ON;");
            data.Add($" SET IDENTITY_INSERT {tableName} OFF;");

            var sql = string.Join(Environment.NewLine, data.ToArray());

            Sql(sql);
        }

        public override void Down()
        {
            Sql($@"DELETE FROM {tableName} WHERE {ID_COLUMN} BETWEEN 1 AND 5");
        }
    }
}
