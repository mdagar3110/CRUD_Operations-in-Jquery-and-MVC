namespace FluentAPI_Start.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TPT : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            AddColumn("dbo.StudentDetails", "StudentDetailsId", c => c.Int(nullable: false));
            AddColumn("dbo.StudentLogin", "StudentLoginId", c => c.Int(nullable: false));
            AddForeignKey("dbo.StudentDetails", "StudentId", "dbo.Student", "StudentId");
            AddForeignKey("dbo.StudentLogin", "StudentId", "dbo.Student", "StudentId");
            CreateIndex("dbo.StudentDetails", "StudentId");
            CreateIndex("dbo.StudentLogin", "StudentId");
            DropColumn("dbo.StudentDetails", "Name");
            DropColumn("dbo.StudentLogin", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentLogin", "Name", c => c.String());
            AddColumn("dbo.StudentDetails", "Name", c => c.String());
            DropIndex("dbo.StudentLogin", new[] { "StudentId" });
            DropIndex("dbo.StudentDetails", new[] { "StudentId" });
            DropForeignKey("dbo.StudentLogin", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentDetails", "StudentId", "dbo.Student");
            DropColumn("dbo.StudentLogin", "StudentLoginId");
            DropColumn("dbo.StudentDetails", "StudentDetailsId");
            DropTable("dbo.Student");
        }
    }
}
