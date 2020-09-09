namespace APPers.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TuesdayMorningFix : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Menu", "BeerName");
            DropColumn("dbo.Menu", "OrderTotal");
            DropColumn("dbo.Menu", "TabName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menu", "TabName", c => c.String());
            AddColumn("dbo.Menu", "OrderTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Menu", "BeerName", c => c.String());
        }
    }
}
