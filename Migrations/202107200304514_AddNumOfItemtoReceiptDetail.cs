namespace ADKT_WebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumOfItemtoReceiptDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Receipt_Detail", "numOfItem", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Receipt_Detail", "numOfItem");
        }
    }
}
