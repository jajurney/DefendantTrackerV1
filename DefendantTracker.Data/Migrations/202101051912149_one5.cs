namespace DefendantTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Conviction", "DefendantID", c => c.Int(nullable: false));
            CreateIndex("dbo.Conviction", "DefendantID");
            AddForeignKey("dbo.Conviction", "DefendantID", "dbo.Defendant", "DefendantID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Conviction", "DefendantID", "dbo.Defendant");
            DropIndex("dbo.Conviction", new[] { "DefendantID" });
            DropColumn("dbo.Conviction", "DefendantID");
        }
    }
}
