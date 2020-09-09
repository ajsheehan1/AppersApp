namespace APPers.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEnum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Beer", "TypeOfBeer", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Beer", "TypeOfBeer", c => c.String(nullable: false));
        }
    }
}
