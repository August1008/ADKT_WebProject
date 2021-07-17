namespace ADKT_WebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetypegender : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Watches", "gender", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Watches", "gender", c => c.Boolean(nullable: false));
        }
    }
}
