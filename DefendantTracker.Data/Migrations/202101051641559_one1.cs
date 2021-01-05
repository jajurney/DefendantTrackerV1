namespace DefendantTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourtHearing", "DefenseAttorneyID", c => c.Int(nullable: false));
            CreateIndex("dbo.CourtHearing", "DefenseAttorneyID");
            AddForeignKey("dbo.CourtHearing", "DefenseAttorneyID", "dbo.DefenseAttorney", "DefenseAttorneyID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourtHearing", "DefenseAttorneyID", "dbo.DefenseAttorney");
            DropIndex("dbo.CourtHearing", new[] { "DefenseAttorneyID" });
            DropColumn("dbo.CourtHearing", "DefenseAttorneyID");
        }
    }
}
