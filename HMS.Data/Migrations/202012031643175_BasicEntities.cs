namespace HMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasicEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccomodationPackages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AccomodationTypeID = c.Int(nullable: false),
                        Name = c.String(),
                        NoOfRoom = c.Int(nullable: false),
                        FeePerNight = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AccomodationTypes", t => t.AccomodationTypeID, cascadeDelete: true)
                .Index(t => t.AccomodationTypeID);
            
            CreateTable(
                "dbo.AccomodationTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Accomodations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AccomodationPackagesID = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AccomodationPackages", t => t.AccomodationPackagesID, cascadeDelete: true)
                .Index(t => t.AccomodationPackagesID);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AccomodationsID = c.Int(nullable: false),
                        FromDate = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accomodations", t => t.AccomodationsID, cascadeDelete: true)
                .Index(t => t.AccomodationsID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "AccomodationsID", "dbo.Accomodations");
            DropForeignKey("dbo.Accomodations", "AccomodationPackagesID", "dbo.AccomodationPackages");
            DropForeignKey("dbo.AccomodationPackages", "AccomodationTypeID", "dbo.AccomodationTypes");
            DropIndex("dbo.Bookings", new[] { "AccomodationsID" });
            DropIndex("dbo.Accomodations", new[] { "AccomodationPackagesID" });
            DropIndex("dbo.AccomodationPackages", new[] { "AccomodationTypeID" });
            DropTable("dbo.Bookings");
            DropTable("dbo.Accomodations");
            DropTable("dbo.AccomodationTypes");
            DropTable("dbo.AccomodationPackages");
        }
    }
}
