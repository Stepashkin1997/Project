namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_Links : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects_Employees", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.Projects_Employees", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Projects_Employees", "EmployeeId");
            CreateIndex("dbo.Projects_Employees", "ProjectId");
            AddForeignKey("dbo.Projects_Employees", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Projects_Employees", "ProjectId", "dbo.Projects", "id", cascadeDelete: true);
            DropColumn("dbo.Projects_Employees", "Employee");
            DropColumn("dbo.Projects_Employees", "Project");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects_Employees", "Project", c => c.Int(nullable: false));
            AddColumn("dbo.Projects_Employees", "Employee", c => c.Int(nullable: false));
            DropForeignKey("dbo.Projects_Employees", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects_Employees", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Projects_Employees", new[] { "ProjectId" });
            DropIndex("dbo.Projects_Employees", new[] { "EmployeeId" });
            DropColumn("dbo.Projects_Employees", "ProjectId");
            DropColumn("dbo.Projects_Employees", "EmployeeId");
        }
    }
}
