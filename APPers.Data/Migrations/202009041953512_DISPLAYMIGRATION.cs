namespace APPers.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DISPLAYMIGRATION : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menu", "BeerName", c => c.String());
            AddColumn("dbo.Menu", "OrderTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Menu", "TabName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menu", "TabName");
            DropColumn("dbo.Menu", "OrderTotal");
            DropColumn("dbo.Menu", "BeerName");
        }
    }
}
