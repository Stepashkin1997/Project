namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_links : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects_Employees", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.Projects_Employees", "ProjectId", c => c.Int(nullable: false));
            DropColumn("dbo.Projects_Employees", "Employee");
            DropColumn("dbo.Projects_Employees", "Project");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects_Employees", "Project", c => c.Int(nullable: false));
            AddColumn("dbo.Projects_Employees", "Employee", c => c.Int(nullable: false));
            DropColumn("dbo.Projects_Employees", "ProjectId");
            DropColumn("dbo.Projects_Employees", "EmployeeId");
        }
    }
}
