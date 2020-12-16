namespace DefendantTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Defendant", "Arrested", c => c.Boolean(nullable: false));
            DropColumn("dbo.Defendant", "Arested");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Defendant", "Arested", c => c.Boolean(nullable: false));
            DropColumn("dbo.Defendant", "Arrested");
        }
    }
}
