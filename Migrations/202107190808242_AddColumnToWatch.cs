namespace ADKT_WebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnToWatch : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Watches", "number", c => c.Int(nullable: false));
            AddColumn("dbo.Watches", "Img_Path1", c => c.String());
            AddColumn("dbo.Watches", "Img_Path2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Watches", "Img_Path2");
            DropColumn("dbo.Watches", "Img_Path1");
            DropColumn("dbo.Watches", "number");
        }
    }
}
