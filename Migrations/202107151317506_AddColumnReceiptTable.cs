namespace ADKT_WebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnReceiptTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Receipts", "CustomerName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Receipts", "CustomerAddress", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Receipts", "CustomerPhone", c => c.String(nullable: false, maxLength: 12));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Receipts", "CustomerPhone");
            DropColumn("dbo.Receipts", "CustomerAddress");
            DropColumn("dbo.Receipts", "CustomerName");
        }
    }
}
