namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeTask : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "ExecutorId", "dbo.Employees");
            DropIndex("dbo.Tasks", new[] { "ExecutorId" });
            AlterColumn("dbo.Tasks", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Tasks", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.Tasks", "Comment", c => c.String(nullable: false));
            AlterColumn("dbo.Tasks", "ExecutorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tasks", "ExecutorId");
            AddForeignKey("dbo.Tasks", "ExecutorId", "dbo.Employees", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "ExecutorId", "dbo.Employees");
            DropIndex("dbo.Tasks", new[] { "ExecutorId" });
            AlterColumn("dbo.Tasks", "ExecutorId", c => c.Int());
            AlterColumn("dbo.Tasks", "Comment", c => c.String());
            AlterColumn("dbo.Tasks", "Status", c => c.String());
            AlterColumn("dbo.Tasks", "Name", c => c.String());
            CreateIndex("dbo.Tasks", "ExecutorId");
            AddForeignKey("dbo.Tasks", "ExecutorId", "dbo.Employees", "Id");
        }
    }
}
