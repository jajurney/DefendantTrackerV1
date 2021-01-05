namespace DefendantTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Conviction", "ArrestID", c => c.Int(nullable: false));
            CreateIndex("dbo.Conviction", "ArrestID");
            AddForeignKey("dbo.Conviction", "ArrestID", "dbo.Arrest", "ArrestID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Conviction", "ArrestID", "dbo.Arrest");
            DropIndex("dbo.Conviction", new[] { "ArrestID" });
            DropColumn("dbo.Conviction", "ArrestID");
        }
    }
}
