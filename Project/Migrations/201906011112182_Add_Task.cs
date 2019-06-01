namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Task : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Status = c.String(),
                        Comment = c.String(),
                        Priority = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        ExecutorId = c.Int(),
                        Employees_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.ExecutorId)
                .ForeignKey("dbo.Employees", t => t.Employees_Id)
                .Index(t => t.AuthorId)
                .Index(t => t.ExecutorId)
                .Index(t => t.Employees_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "Employees_Id", "dbo.Employees");
            DropForeignKey("dbo.Tasks", "ExecutorId", "dbo.Employees");
            DropForeignKey("dbo.Tasks", "AuthorId", "dbo.Employees");
            DropIndex("dbo.Tasks", new[] { "Employees_Id" });
            DropIndex("dbo.Tasks", new[] { "ExecutorId" });
            DropIndex("dbo.Tasks", new[] { "AuthorId" });
            DropTable("dbo.Tasks");
        }
    }
}
