namespace about.me.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contact_Profile",
                c => new
                    {
                        Contact_ProfileID = c.Long(nullable: false, identity: true),
                        ProfileID = c.Long(nullable: false),
                        Direction = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                        Facebook = c.String(),
                        Twitter = c.String(),
                        Linkedin = c.String(),
                    })
                .PrimaryKey(t => t.Contact_ProfileID)
                .ForeignKey("dbo.Profiles", t => t.ProfileID, cascadeDelete: true)
                .Index(t => t.ProfileID);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        ProfileID = c.Long(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Profesion = c.String(),
                        Contact_Contact_ProfileID = c.Long(),
                        Education_EducationID = c.Long(),
                        Experience_ExperienceID = c.Long(),
                        Habilities_HabilitiesID = c.Long(),
                        Hability_HabilitiesID = c.Long(),
                        Contact_Profile_Contact_ProfileID = c.Long(),
                    })
                .PrimaryKey(t => t.ProfileID)
                .ForeignKey("dbo.Contact_Profile", t => t.Contact_Contact_ProfileID)
                .ForeignKey("dbo.Educations", t => t.Education_EducationID)
                .ForeignKey("dbo.Experiences", t => t.Experience_ExperienceID)
                .ForeignKey("dbo.Habilities", t => t.Habilities_HabilitiesID)
                .ForeignKey("dbo.Habilities", t => t.Hability_HabilitiesID)
                .ForeignKey("dbo.Contact_Profile", t => t.Contact_Profile_Contact_ProfileID)
                .Index(t => t.Contact_Contact_ProfileID)
                .Index(t => t.Education_EducationID)
                .Index(t => t.Experience_ExperienceID)
                .Index(t => t.Habilities_HabilitiesID)
                .Index(t => t.Hability_HabilitiesID)
                .Index(t => t.Contact_Profile_Contact_ProfileID);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        EducationID = c.Long(nullable: false, identity: true),
                        ProfileID = c.Long(nullable: false),
                        NameCareer = c.String(),
                        NameUniversity = c.String(),
                        DateStart = c.String(),
                        DateEnd = c.String(),
                        ShortDescription = c.String(),
                        Description = c.String(),
                        Profile_ProfileID = c.Long(),
                    })
                .PrimaryKey(t => t.EducationID)
                .ForeignKey("dbo.Profiles", t => t.ProfileID, cascadeDelete: true)
                .ForeignKey("dbo.Profiles", t => t.Profile_ProfileID)
                .Index(t => t.ProfileID)
                .Index(t => t.Profile_ProfileID);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        ExperienceID = c.Long(nullable: false, identity: true),
                        ProfileID = c.Long(nullable: false),
                        NameCharge = c.String(),
                        Company = c.String(),
                        DateStart = c.String(),
                        DateEnd = c.String(),
                        ShortDescription = c.String(),
                        Description = c.String(),
                        Profile_ProfileID = c.Long(),
                    })
                .PrimaryKey(t => t.ExperienceID)
                .ForeignKey("dbo.Profiles", t => t.ProfileID, cascadeDelete: true)
                .ForeignKey("dbo.Profiles", t => t.Profile_ProfileID)
                .Index(t => t.ProfileID)
                .Index(t => t.Profile_ProfileID);
            
            CreateTable(
                "dbo.Habilities",
                c => new
                    {
                        HabilitiesID = c.Long(nullable: false, identity: true),
                        ProfileID = c.Long(nullable: false),
                        NameHability = c.String(),
                        Porcentage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HabilitiesID)
                .ForeignKey("dbo.Profiles", t => t.ProfileID, cascadeDelete: true)
                .Index(t => t.ProfileID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profiles", "Contact_Profile_Contact_ProfileID", "dbo.Contact_Profile");
            DropForeignKey("dbo.Contact_Profile", "ProfileID", "dbo.Profiles");
            DropForeignKey("dbo.Profiles", "Hability_HabilitiesID", "dbo.Habilities");
            DropForeignKey("dbo.Profiles", "Habilities_HabilitiesID", "dbo.Habilities");
            DropForeignKey("dbo.Habilities", "ProfileID", "dbo.Profiles");
            DropForeignKey("dbo.Experiences", "Profile_ProfileID", "dbo.Profiles");
            DropForeignKey("dbo.Profiles", "Experience_ExperienceID", "dbo.Experiences");
            DropForeignKey("dbo.Experiences", "ProfileID", "dbo.Profiles");
            DropForeignKey("dbo.Educations", "Profile_ProfileID", "dbo.Profiles");
            DropForeignKey("dbo.Profiles", "Education_EducationID", "dbo.Educations");
            DropForeignKey("dbo.Educations", "ProfileID", "dbo.Profiles");
            DropForeignKey("dbo.Profiles", "Contact_Contact_ProfileID", "dbo.Contact_Profile");
            DropIndex("dbo.Habilities", new[] { "ProfileID" });
            DropIndex("dbo.Experiences", new[] { "Profile_ProfileID" });
            DropIndex("dbo.Experiences", new[] { "ProfileID" });
            DropIndex("dbo.Educations", new[] { "Profile_ProfileID" });
            DropIndex("dbo.Educations", new[] { "ProfileID" });
            DropIndex("dbo.Profiles", new[] { "Contact_Profile_Contact_ProfileID" });
            DropIndex("dbo.Profiles", new[] { "Hability_HabilitiesID" });
            DropIndex("dbo.Profiles", new[] { "Habilities_HabilitiesID" });
            DropIndex("dbo.Profiles", new[] { "Experience_ExperienceID" });
            DropIndex("dbo.Profiles", new[] { "Education_EducationID" });
            DropIndex("dbo.Profiles", new[] { "Contact_Contact_ProfileID" });
            DropIndex("dbo.Contact_Profile", new[] { "ProfileID" });
            DropTable("dbo.Habilities");
            DropTable("dbo.Experiences");
            DropTable("dbo.Educations");
            DropTable("dbo.Profiles");
            DropTable("dbo.Contact_Profile");
        }
    }
}
