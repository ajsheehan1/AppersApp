namespace APPers.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Beer", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Beer", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Beer", "Description");
            DropColumn("dbo.Beer", "Price");
        }
    }
}
