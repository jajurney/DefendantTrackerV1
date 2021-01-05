namespace DefendantTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourtHearing", "DefendantID", c => c.Int(nullable: false));
            AddColumn("dbo.CourtHearing", "ArrestID", c => c.Int(nullable: false));
            CreateIndex("dbo.CourtHearing", "DefendantID");
            CreateIndex("dbo.CourtHearing", "ArrestID");
            AddForeignKey("dbo.CourtHearing", "ArrestID", "dbo.Arrest", "ArrestID", cascadeDelete: false);
            AddForeignKey("dbo.CourtHearing", "DefendantID", "dbo.Defendant", "DefendantID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourtHearing", "DefendantID", "dbo.Defendant");
            DropForeignKey("dbo.CourtHearing", "ArrestID", "dbo.Arrest");
            DropIndex("dbo.CourtHearing", new[] { "ArrestID" });
            DropIndex("dbo.CourtHearing", new[] { "DefendantID" });
            DropColumn("dbo.CourtHearing", "ArrestID");
            DropColumn("dbo.CourtHearing", "DefendantID");
        }
    }
}
