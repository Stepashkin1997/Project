namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Taskv2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "AuthorId", "dbo.Employees");
            AddColumn("dbo.Tasks", "ExecutorId", c => c.Int(nullable: false));
            AddColumn("dbo.Tasks", "Employees_Id", c => c.Int());
            CreateIndex("dbo.Tasks", "ExecutorId");
            CreateIndex("dbo.Tasks", "Employees_Id");
            AddForeignKey("dbo.Tasks", "ExecutorId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tasks", "Employees_Id", "dbo.Employees", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "Employees_Id", "dbo.Employees");
            DropForeignKey("dbo.Tasks", "ExecutorId", "dbo.Employees");
            DropIndex("dbo.Tasks", new[] { "Employees_Id" });
            DropIndex("dbo.Tasks", new[] { "ExecutorId" });
            DropColumn("dbo.Tasks", "Employees_Id");
            DropColumn("dbo.Tasks", "ExecutorId");
            AddForeignKey("dbo.Tasks", "AuthorId", "dbo.Employees", "Id", cascadeDelete: true);
        }
    }
}
