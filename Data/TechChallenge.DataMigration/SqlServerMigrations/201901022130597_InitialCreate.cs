namespace TechChallenge.DataMigration.SqlServerMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
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
                        DeletionReason = c.String()
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
                        DeletionReason = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Races",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Status = c.String(),
                        Start = c.DateTime(nullable: false),
                        DateDeleted = c.DateTime(),
                        DeletionReason = c.String(),
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
                        DeletionReason = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Races", t => t.RaceId, cascadeDelete: true)
                .Index(t => t.RaceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Horses", "RaceId", "dbo.Races");
            DropForeignKey("dbo.Bets", "RaceId", "dbo.Races");
            DropForeignKey("dbo.Bets", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Horses", new[] { "RaceId" });
            DropIndex("dbo.Bets", new[] { "RaceId" });
            DropIndex("dbo.Bets", new[] { "CustomerId" });
            DropTable("dbo.Horses");
            DropTable("dbo.Races");
            DropTable("dbo.Customers");
            DropTable("dbo.Bets");
        }
    }
}
