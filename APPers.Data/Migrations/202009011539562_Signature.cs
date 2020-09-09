namespace APPers.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Signature : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tab", "Signature", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tab", "Signature");
        }
    }
}
