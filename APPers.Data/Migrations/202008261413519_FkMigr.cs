namespace APPers.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FkMigr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Location = c.Int(nullable: false),
                        BeerId = c.Int(nullable: false),
                        OrderTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderComplete = c.Boolean(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Beer", t => t.BeerId, cascadeDelete: true)
                .Index(t => t.BeerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menu", "BeerId", "dbo.Beer");
            DropIndex("dbo.Menu", new[] { "BeerId" });
            DropTable("dbo.Menu");
        }
    }
}
