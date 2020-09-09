namespace APPers.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Beer", "InRotation", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Beer", "InRotation");
        }
    }
}
