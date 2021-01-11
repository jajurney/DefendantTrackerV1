namespace DefendantTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Arrest",
                c => new
                    {
                        ArrestID = c.Int(nullable: false, identity: true),
                        ArrestDate = c.DateTime(nullable: false),
                        StreetName = c.String(nullable: false),
                        ArrestCity = c.String(nullable: false),
                        ArrestCounty = c.String(nullable: false),
                        ArrestState = c.String(nullable: false),
                        ArrestZipcode = c.Int(nullable: false),
                        ArrestLocation = c.String(nullable: false),
                        ArrestDesc = c.String(),
                        DefendantID = c.Int(nullable: false),
                        OfficerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArrestID)
                .ForeignKey("dbo.Defendant", t => t.DefendantID, cascadeDelete: false)
                .ForeignKey("dbo.Officer", t => t.OfficerID, cascadeDelete: false)
                .Index(t => t.DefendantID)
                .Index(t => t.OfficerID);
            
            CreateTable(
                "dbo.Defendant",
                c => new
                    {
                        DefendantID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(nullable: false),
                        FullName = c.String(nullable: false),
                        StreetAddress = c.String(nullable: false),
                        City = c.String(nullable: false),
                        County = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Zipcode = c.Int(nullable: false),
                        FullLocation = c.String(nullable: false),
                        Prosecuted = c.Boolean(nullable: false),
                        Arrested = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DefendantID);
            
            CreateTable(
                "dbo.Officer",
                c => new
                    {
                        OfficerID = c.Int(nullable: false, identity: true),
                        BadgeID = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        OFullName = c.String(nullable: false),
                        DepartmentCity = c.String(nullable: false),
                        DepartmentCounty = c.String(nullable: false),
                        DepartmentState = c.String(nullable: false),
                        DepartmentZipcode = c.Int(nullable: false),
                        DepartmentLocation = c.String(nullable: false),
                        DepartmentName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.OfficerID);
            
            CreateTable(
                "dbo.Conviction",
                c => new
                    {
                        ConvicID = c.Int(nullable: false, identity: true),
                        StreetAddress = c.String(nullable: false),
                        City = c.String(nullable: false),
                        County = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Zipcode = c.Int(nullable: false),
                        FullLocation = c.String(nullable: false),
                        DateOfConviction = c.DateTime(nullable: false),
                        ConvictionSeverity = c.Int(nullable: false),
                        ArrestID = c.Int(nullable: false),
                        DefendantID = c.Int(nullable: false),
                        CourtHearingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConvicID)
                .ForeignKey("dbo.Arrest", t => t.ArrestID, cascadeDelete: false)
                .ForeignKey("dbo.CourtHearing", t => t.CourtHearingID, cascadeDelete: false)
                .ForeignKey("dbo.Defendant", t => t.DefendantID, cascadeDelete: false)
                .Index(t => t.ArrestID)
                .Index(t => t.DefendantID)
                .Index(t => t.CourtHearingID);
            
            CreateTable(
                "dbo.CourtHearing",
                c => new
                    {
                        CourtHearingID = c.Int(nullable: false, identity: true),
                        HearingDesc = c.String(nullable: false),
                        CourtDate = c.DateTime(nullable: false),
                        CourtAddress = c.String(nullable: false),
                        CourtCity = c.String(nullable: false),
                        CourtCounty = c.String(nullable: false),
                        CourtState = c.String(nullable: false),
                        CourtZipcode = c.Int(nullable: false),
                        FullLocation = c.String(nullable: false),
                        StateAttorneyID = c.Int(nullable: false),
                        DefenseAttorneyID = c.Int(nullable: false),
                        OfficerID = c.Int(nullable: false),
                        DefendantID = c.Int(nullable: false),
                        ArrestID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourtHearingID)
                .ForeignKey("dbo.Arrest", t => t.ArrestID, cascadeDelete: false)
                .ForeignKey("dbo.Defendant", t => t.DefendantID, cascadeDelete: false)
                .ForeignKey("dbo.DefenseAttorney", t => t.DefenseAttorneyID, cascadeDelete: false)
                .ForeignKey("dbo.Officer", t => t.OfficerID, cascadeDelete: false)
                .ForeignKey("dbo.StateAttorney", t => t.StateAttorneyID, cascadeDelete: false)
                .Index(t => t.StateAttorneyID)
                .Index(t => t.DefenseAttorneyID)
                .Index(t => t.OfficerID)
                .Index(t => t.DefendantID)
                .Index(t => t.ArrestID);
            
            CreateTable(
                "dbo.DefenseAttorney",
                c => new
                    {
                        DefenseAttorneyID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        FullName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DefenseAttorneyID);
            
            CreateTable(
                "dbo.StateAttorney",
                c => new
                    {
                        StateAttorneyID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        FullName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StateAttorneyID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Conviction", "DefendantID", "dbo.Defendant");
            DropForeignKey("dbo.Conviction", "CourtHearingID", "dbo.CourtHearing");
            DropForeignKey("dbo.CourtHearing", "StateAttorneyID", "dbo.StateAttorney");
            DropForeignKey("dbo.CourtHearing", "OfficerID", "dbo.Officer");
            DropForeignKey("dbo.CourtHearing", "DefenseAttorneyID", "dbo.DefenseAttorney");
            DropForeignKey("dbo.CourtHearing", "DefendantID", "dbo.Defendant");
            DropForeignKey("dbo.CourtHearing", "ArrestID", "dbo.Arrest");
            DropForeignKey("dbo.Conviction", "ArrestID", "dbo.Arrest");
            DropForeignKey("dbo.Arrest", "OfficerID", "dbo.Officer");
            DropForeignKey("dbo.Arrest", "DefendantID", "dbo.Defendant");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.CourtHearing", new[] { "ArrestID" });
            DropIndex("dbo.CourtHearing", new[] { "DefendantID" });
            DropIndex("dbo.CourtHearing", new[] { "OfficerID" });
            DropIndex("dbo.CourtHearing", new[] { "DefenseAttorneyID" });
            DropIndex("dbo.CourtHearing", new[] { "StateAttorneyID" });
            DropIndex("dbo.Conviction", new[] { "CourtHearingID" });
            DropIndex("dbo.Conviction", new[] { "DefendantID" });
            DropIndex("dbo.Conviction", new[] { "ArrestID" });
            DropIndex("dbo.Arrest", new[] { "OfficerID" });
            DropIndex("dbo.Arrest", new[] { "DefendantID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.StateAttorney");
            DropTable("dbo.DefenseAttorney");
            DropTable("dbo.CourtHearing");
            DropTable("dbo.Conviction");
            DropTable("dbo.Officer");
            DropTable("dbo.Defendant");
            DropTable("dbo.Arrest");
        }
    }
}
