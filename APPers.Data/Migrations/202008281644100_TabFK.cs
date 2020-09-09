namespace APPers.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabFK : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tab",
                c => new
                    {
                        TabId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        GrandTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TabPaid = c.Boolean(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.TabId);
            
            AddColumn("dbo.Menu", "TabId", c => c.Int(nullable: false));
            CreateIndex("dbo.Menu", "TabId");
            AddForeignKey("dbo.Menu", "TabId", "dbo.Tab", "TabId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menu", "TabId", "dbo.Tab");
            DropIndex("dbo.Menu", new[] { "TabId" });
            DropColumn("dbo.Menu", "TabId");
            DropTable("dbo.Tab");
        }
    }
}
