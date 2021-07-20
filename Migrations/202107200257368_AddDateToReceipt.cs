namespace ADKT_WebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateToReceipt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Receipts", "date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Receipts", "date");
        }
    }
}
