namespace DefendantTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourtHearing", "StateAttorneyID", c => c.Int(nullable: false));
            CreateIndex("dbo.CourtHearing", "StateAttorneyID");
            AddForeignKey("dbo.CourtHearing", "StateAttorneyID", "dbo.StateAttorney", "StateAttorneyID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourtHearing", "StateAttorneyID", "dbo.StateAttorney");
            DropIndex("dbo.CourtHearing", new[] { "StateAttorneyID" });
            DropColumn("dbo.CourtHearing", "StateAttorneyID");
        }
    }
}
