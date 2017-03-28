namespace FluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderId);
            
            AddColumn("dbo.tblUser", "OrdId", c => c.Int(nullable: false));
            AddForeignKey("dbo.tblUser", "OrdId", "dbo.Orders", "OrderId", cascadeDelete: true);
            CreateIndex("dbo.tblUser", "OrdId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.tblUser", new[] { "OrdId" });
            DropForeignKey("dbo.tblUser", "OrdId", "dbo.Orders");
            DropColumn("dbo.tblUser", "OrdId");
            DropTable("dbo.Orders");
        }
    }
}
