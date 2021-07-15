namespace ADKT_WebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableBrandWatchReceiptAndDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Receipt_Detail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WatchId = c.Int(nullable: false),
                        Watch_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Watches", t => t.Watch_Id)
                .Index(t => t.Watch_Id);
            
            CreateTable(
                "dbo.Watches",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        name = c.String(nullable: false, maxLength: 255),
                        gender = c.Boolean(nullable: false),
                        glass = c.String(nullable: false, maxLength: 255),
                        waterproof = c.Int(nullable: false),
                        strap = c.String(nullable: false, maxLength: 255),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.Receipts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Receipt_DetailId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Receipt_Detail", t => t.Receipt_DetailId, cascadeDelete: true)
                .Index(t => t.Receipt_DetailId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receipts", "Receipt_DetailId", "dbo.Receipt_Detail");
            DropForeignKey("dbo.Receipt_Detail", "Watch_Id", "dbo.Watches");
            DropForeignKey("dbo.Watches", "BrandId", "dbo.Brands");
            DropIndex("dbo.Receipts", new[] { "Receipt_DetailId" });
            DropIndex("dbo.Watches", new[] { "BrandId" });
            DropIndex("dbo.Receipt_Detail", new[] { "Watch_Id" });
            DropTable("dbo.Receipts");
            DropTable("dbo.Watches");
            DropTable("dbo.Receipt_Detail");
            DropTable("dbo.Brands");
        }
    }
}
