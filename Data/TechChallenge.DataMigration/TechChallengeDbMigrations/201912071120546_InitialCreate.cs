using System.Data.Entity.Migrations;
using TechChallenge.DataMigration.TechChallengeDbMigrations.Scripts;

namespace TechChallenge.DataMigration.TechChallengeDbMigrations
{
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bets",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CustomerId = c.Int(nullable: false),
                    HorseId = c.Int(nullable: false),
                    RaceId = c.Int(nullable: false),
                    Stake = c.Double(nullable: false),
                    DateDeleted = c.DateTime(),
                    DeletedBy = c.String(maxLength: 255),
                    DeletionReason = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Races", t => t.RaceId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.RaceId);

            CreateTable(
                "dbo.Customers",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    DateDeleted = c.DateTime(),
                    DeletedBy = c.String(maxLength: 255),
                    DeletionReason = c.String(),
                    Discriminator = c.String(nullable: true, maxLength: 255),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Horses",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    RaceId = c.Int(nullable: false),
                    Name = c.String(),
                    Odds = c.Double(nullable: false),
                    DateDeleted = c.DateTime(),
                    DeletedBy = c.String(maxLength: 255),
                    DeletionReason = c.String(),
                    Discriminator = c.String(nullable: true, maxLength: 255),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Races", t => t.RaceId, cascadeDelete: true)
                .Index(t => t.RaceId);

            CreateTable(
                "dbo.Races",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Status = c.String(),
                    Start = c.DateTime(nullable: false),
                    DateDeleted = c.DateTime(),
                    DeletedBy = c.String(maxLength: 255),
                    DeletionReason = c.String(),
                })
                .PrimaryKey(t => t.Id);

            //NLog
            Sql(NLogSql.GetCreateLogTable());
            Sql(NLogSql.GetInsertLogSp());
        }

        public override void Down()
        {
            DropForeignKey("dbo.Horses", "RaceId", "dbo.Races");
            DropForeignKey("dbo.Bets", "RaceId", "dbo.Races");
            DropForeignKey("dbo.Bets", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Horses", new[] { "RaceId" });
            DropIndex("dbo.Bets", new[] { "RaceId" });
            DropIndex("dbo.Bets", new[] { "CustomerId" });
            DropTable("dbo.Races");
            DropTable("dbo.Horses");
            DropTable("dbo.Customers");
            DropTable("dbo.Bets");

            //NLog
            DropStoredProcedure(NLogSql.GetDropSp());
            DropTable("dbo.Logs");
        }
    }
}
