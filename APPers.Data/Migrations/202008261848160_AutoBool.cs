namespace APPers.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutoBool : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Beer", "InRotation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Beer", "InRotation", c => c.Boolean(nullable: false));
        }
    }
}
