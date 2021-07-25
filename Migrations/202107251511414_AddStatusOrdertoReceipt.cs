namespace ADKT_WebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusOrdertoReceipt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Receipts", "status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Receipts", "status");
        }
    }
}
