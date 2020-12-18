namespace DefendantTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class five : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.StateAttorney");
            AddColumn("dbo.StateAttorney", "StateAttorneyID", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.StateAttorney", "StateAttorneyID");
            DropColumn("dbo.StateAttorney", "DefenseAttorneyID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StateAttorney", "DefenseAttorneyID", c => c.Guid(nullable: false));
            DropPrimaryKey("dbo.StateAttorney");
            DropColumn("dbo.StateAttorney", "StateAttorneyID");
            AddPrimaryKey("dbo.StateAttorney", "DefenseAttorneyID");
        }
    }
}
