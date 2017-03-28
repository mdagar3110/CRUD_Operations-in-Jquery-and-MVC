namespace FluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblUser",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 128, unicode: false),
                        Address = c.String(unicode: false),
                        ContactNo = c.String(),
                    })
                .PrimaryKey(t => new { t.UserId, t.Name });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblUser");
        }
    }
}
