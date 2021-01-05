namespace DefendantTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourtHearing", "OfficerID", c => c.Int(nullable: false));
            CreateIndex("dbo.CourtHearing", "OfficerID");
            AddForeignKey("dbo.CourtHearing", "OfficerID", "dbo.Officer", "OfficerID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourtHearing", "OfficerID", "dbo.Officer");
            DropIndex("dbo.CourtHearing", new[] { "OfficerID" });
            DropColumn("dbo.CourtHearing", "OfficerID");
        }
    }
}
