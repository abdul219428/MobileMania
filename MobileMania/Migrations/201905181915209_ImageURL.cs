namespace MobileMania.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageURL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MobileInfoes", "ImageURL", c => c.String());
            DropColumn("dbo.MobileInfoes", "imgSrc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MobileInfoes", "imgSrc", c => c.String());
            DropColumn("dbo.MobileInfoes", "ImageURL");
        }
    }
}
