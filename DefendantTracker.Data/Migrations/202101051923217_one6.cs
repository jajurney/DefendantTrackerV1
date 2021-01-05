namespace DefendantTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Conviction", "CourtHearingID", c => c.Int(nullable: false));
            CreateIndex("dbo.Conviction", "CourtHearingID");
            AddForeignKey("dbo.Conviction", "CourtHearingID", "dbo.CourtHearing", "CourtHearingID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Conviction", "CourtHearingID", "dbo.CourtHearing");
            DropIndex("dbo.Conviction", new[] { "CourtHearingID" });
            DropColumn("dbo.Conviction", "CourtHearingID");
        }
    }
}
