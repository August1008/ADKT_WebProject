namespace ADKT_WebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBrandImgToBrand : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brands", "brandBanner", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Brands", "brandBanner");
        }
    }
}
