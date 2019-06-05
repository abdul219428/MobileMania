namespace MobileMania.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MobileInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MobileName = c.String(),
                        ProcessorName = c.String(),
                        AndroidOsName = c.String(),
                        AndroidOsVersion = c.Int(nullable: false),
                        RearCameraPrimary = c.String(),
                        RearCameraSecondary = c.String(),
                        RearCameraTertiary = c.String(),
                        FrontCameraPrimary = c.String(),
                        FrontCameraSecondary = c.String(),
                        RAM = c.Int(nullable: false),
                        BatterySize = c.Int(nullable: false),
                        ScreenSize = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        Price = c.Int(nullable: false),
                        ScreenResolution = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MobileInfoes");
        }
    }
}
