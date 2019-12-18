using Eml.DataRepository;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using TechChallenge.Business.Common.Entities.TechChallengeDb;

namespace TechChallenge.DataMigration.TechChallengeDbMigrations
{
    public partial class SeedHorses : DbMigration
    {
        private const string ID_COLUMN = "Id";
        private const string COLUMNS = "Id,[RaceId],[Name],[Odds]";
        private const string SAMPLE_DATA = "SampleDataSources";

        private readonly string tableName;

        public SeedHorses()
        {
            tableName = GetType().Name.Replace("Seed", string.Empty);
        }

        public override void Up()
        {
            var races = Seeder.GetJsonStubs<Race>("races", SAMPLE_DATA);
            var initialData = races.SelectMany(r =>
            {
                r.Horses.ForEach(h => h.RaceId = r.Id);

                return r.Horses;

            }).ToList();

            var data = initialData.ConvertAll(r => $" INSERT INTO {tableName} ({COLUMNS}) VALUES ({r.Id}, {r.RaceId}, '{r.Name}', {r.Odds})");

            data.Insert(0, $" SET IDENTITY_INSERT {tableName} ON;");
            data.Add($" SET IDENTITY_INSERT {tableName} OFF;");

            var sql = string.Join(Environment.NewLine, data.ToArray());

            Sql(sql);
        }

        public override void Down()
        {
            Sql($@"DELETE FROM {tableName} WHERE {ID_COLUMN} IN (11, 12, 13, 21, 22, 23, 21, 32, 33, 41, 42, 43, 51, 52, 53, 54, 55) ");
        }
    }
}