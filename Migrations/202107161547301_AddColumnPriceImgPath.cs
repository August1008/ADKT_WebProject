namespace ADKT_WebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnPriceImgPath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Watches", "price", c => c.Double(nullable: false));
            AddColumn("dbo.Watches", "Img_Path", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Watches", "Img_Path");
            DropColumn("dbo.Watches", "price");
        }
    }
}
