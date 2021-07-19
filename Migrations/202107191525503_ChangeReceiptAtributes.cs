namespace ADKT_WebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeReceiptAtributes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Receipt_Detail", "Receipt_Id", "dbo.Receipts");
            DropIndex("dbo.Receipt_Detail", new[] { "Receipt_Id" });
            DropColumn("dbo.Receipt_Detail", "ReceiptId");
            RenameColumn(table: "dbo.Receipt_Detail", name: "Receipt_Id", newName: "ReceiptId");
            DropPrimaryKey("dbo.Receipts");
            AddColumn("dbo.Receipts", "CustomerId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Receipt_Detail", "ReceiptId", c => c.Int(nullable: false));
            AlterColumn("dbo.Receipts", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Receipts", "Id");
            CreateIndex("dbo.Receipt_Detail", "ReceiptId");
            CreateIndex("dbo.Receipts", "CustomerId");
            AddForeignKey("dbo.Receipts", "CustomerId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Receipt_Detail", "ReceiptId", "dbo.Receipts", "Id", cascadeDelete: true);
            DropColumn("dbo.Receipts", "CustomerName");
            DropColumn("dbo.Receipts", "CustomerAddress");
            DropColumn("dbo.Receipts", "CustomerPhone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Receipts", "CustomerPhone", c => c.String(nullable: false, maxLength: 12));
            AddColumn("dbo.Receipts", "CustomerAddress", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Receipts", "CustomerName", c => c.String(nullable: false, maxLength: 100));
            DropForeignKey("dbo.Receipt_Detail", "ReceiptId", "dbo.Receipts");
            DropForeignKey("dbo.Receipts", "CustomerId", "dbo.AspNetUsers");
            DropIndex("dbo.Receipts", new[] { "CustomerId" });
            DropIndex("dbo.Receipt_Detail", new[] { "ReceiptId" });
            DropPrimaryKey("dbo.Receipts");
            AlterColumn("dbo.Receipts", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Receipt_Detail", "ReceiptId", c => c.String(maxLength: 128));
            DropColumn("dbo.Receipts", "CustomerId");
            AddPrimaryKey("dbo.Receipts", "Id");
            RenameColumn(table: "dbo.Receipt_Detail", name: "ReceiptId", newName: "Receipt_Id");
            AddColumn("dbo.Receipt_Detail", "ReceiptId", c => c.Int(nullable: false));
            CreateIndex("dbo.Receipt_Detail", "Receipt_Id");
            AddForeignKey("dbo.Receipt_Detail", "Receipt_Id", "dbo.Receipts", "Id");
        }
    }
}
