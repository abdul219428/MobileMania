namespace MobileMania.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imgSrcBrandName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MobileInfoes", "BrandName", c => c.String());
            AddColumn("dbo.MobileInfoes", "imgSrc", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MobileInfoes", "imgSrc");
            DropColumn("dbo.MobileInfoes", "BrandName");
        }
    }
}
