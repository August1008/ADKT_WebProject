namespace ADKT_WebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixAttributeOfReceiptAndDetail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Receipts", "Receipt_DetailId", "dbo.Receipt_Detail");
            DropIndex("dbo.Receipts", new[] { "Receipt_DetailId" });
            AddColumn("dbo.Receipt_Detail", "ReceiptId", c => c.Int(nullable: false));
            AddColumn("dbo.Receipt_Detail", "Receipt_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Receipt_Detail", "Receipt_Id");
            AddForeignKey("dbo.Receipt_Detail", "Receipt_Id", "dbo.Receipts", "Id");
            DropColumn("dbo.Receipts", "Receipt_DetailId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Receipts", "Receipt_DetailId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Receipt_Detail", "Receipt_Id", "dbo.Receipts");
            DropIndex("dbo.Receipt_Detail", new[] { "Receipt_Id" });
            DropColumn("dbo.Receipt_Detail", "Receipt_Id");
            DropColumn("dbo.Receipt_Detail", "ReceiptId");
            CreateIndex("dbo.Receipts", "Receipt_DetailId");
            AddForeignKey("dbo.Receipts", "Receipt_DetailId", "dbo.Receipt_Detail", "Id", cascadeDelete: true);
        }
    }
}
