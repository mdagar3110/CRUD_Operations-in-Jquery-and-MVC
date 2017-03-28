namespace FluentAPI_Start.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TPC : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentDetails",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        Address = c.String(),
                        ContactNo = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.StudentLogin",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            DropTable("dbo.Students");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        ContactNo = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.StudentId);
            
            DropTable("dbo.StudentLogin");
            DropTable("dbo.StudentDetails");
        }
    }
}
