namespace APPers.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuildingOrderScreens : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Menu", "OrderTotal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menu", "OrderTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
