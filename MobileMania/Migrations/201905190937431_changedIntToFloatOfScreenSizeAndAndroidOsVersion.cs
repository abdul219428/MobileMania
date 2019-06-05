namespace MobileMania.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedIntToFloatOfScreenSizeAndAndroidOsVersion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MobileInfoes", "AndroidOsVersion", c => c.Single(nullable: false));
            AlterColumn("dbo.MobileInfoes", "ScreenSize", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MobileInfoes", "ScreenSize", c => c.Int(nullable: false));
            AlterColumn("dbo.MobileInfoes", "AndroidOsVersion", c => c.Int(nullable: false));
        }
    }
}
