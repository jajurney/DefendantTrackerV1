namespace DefendantTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Defendant", "DFullName", c => c.String(nullable: false));
            AddColumn("dbo.DefenseAttorney", "DAFullName", c => c.String(nullable: false));
            AddColumn("dbo.StateAttorney", "SAFullName", c => c.String(nullable: false));
            DropColumn("dbo.Defendant", "FullName");
            DropColumn("dbo.DefenseAttorney", "FullName");
            DropColumn("dbo.StateAttorney", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StateAttorney", "FullName", c => c.String(nullable: false));
            AddColumn("dbo.DefenseAttorney", "FullName", c => c.String(nullable: false));
            AddColumn("dbo.Defendant", "FullName", c => c.String(nullable: false));
            DropColumn("dbo.StateAttorney", "SAFullName");
            DropColumn("dbo.DefenseAttorney", "DAFullName");
            DropColumn("dbo.Defendant", "DFullName");
        }
    }
}
