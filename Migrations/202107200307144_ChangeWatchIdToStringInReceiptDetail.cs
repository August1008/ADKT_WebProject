namespace ADKT_WebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeWatchIdToStringInReceiptDetail : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Receipt_Detail", new[] { "Watch_Id" });
            DropColumn("dbo.Receipt_Detail", "WatchId");
            RenameColumn(table: "dbo.Receipt_Detail", name: "Watch_Id", newName: "WatchId");
            AlterColumn("dbo.Receipt_Detail", "WatchId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Receipt_Detail", "WatchId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Receipt_Detail", new[] { "WatchId" });
            AlterColumn("dbo.Receipt_Detail", "WatchId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Receipt_Detail", name: "WatchId", newName: "Watch_Id");
            AddColumn("dbo.Receipt_Detail", "WatchId", c => c.Int(nullable: false));
            CreateIndex("dbo.Receipt_Detail", "Watch_Id");
        }
    }
}
