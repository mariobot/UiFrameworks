namespace about.me.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfileclass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Profiles", "Hability_HabilitiesID", "dbo.Habilities");
            DropIndex("dbo.Profiles", new[] { "Hability_HabilitiesID" });
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        Profile_Contact_ProfileID = c.Long(),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Contact_Profile", t => t.Profile_Contact_ProfileID)
                .Index(t => t.Profile_Contact_ProfileID);
            
            AddColumn("dbo.Contact_Profile", "Cellphone", c => c.String());
            AddColumn("dbo.Contact_Profile", "Skype", c => c.String());
            AddColumn("dbo.Habilities", "Profile_ProfileID", c => c.Long());
            CreateIndex("dbo.Habilities", "Profile_ProfileID");
            AddForeignKey("dbo.Habilities", "Profile_ProfileID", "dbo.Profiles", "ProfileID");
            DropColumn("dbo.Profiles", "Hability_HabilitiesID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "Hability_HabilitiesID", c => c.Long());
            DropForeignKey("dbo.Habilities", "Profile_ProfileID", "dbo.Profiles");
            DropForeignKey("dbo.Files", "Profile_Contact_ProfileID", "dbo.Contact_Profile");
            DropIndex("dbo.Habilities", new[] { "Profile_ProfileID" });
            DropIndex("dbo.Files", new[] { "Profile_Contact_ProfileID" });
            DropColumn("dbo.Habilities", "Profile_ProfileID");
            DropColumn("dbo.Contact_Profile", "Skype");
            DropColumn("dbo.Contact_Profile", "Cellphone");
            DropTable("dbo.Files");
            CreateIndex("dbo.Profiles", "Hability_HabilitiesID");
            AddForeignKey("dbo.Profiles", "Hability_HabilitiesID", "dbo.Habilities", "HabilitiesID");
        }
    }
}
