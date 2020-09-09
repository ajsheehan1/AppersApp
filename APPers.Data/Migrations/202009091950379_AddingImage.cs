namespace APPers.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Beer", "ImageURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Beer", "ImageURL");
        }
    }
}
