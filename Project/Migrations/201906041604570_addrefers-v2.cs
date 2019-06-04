namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrefersv2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "ManagerId", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "Employees_Id", c => c.Int());
            CreateIndex("dbo.Projects", "Employees_Id");
            AddForeignKey("dbo.Projects", "Employees_Id", "dbo.Employees", "Id");
            DropColumn("dbo.Projects", "Manager");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "Manager", c => c.Int(nullable: false));
            DropForeignKey("dbo.Projects", "Employees_Id", "dbo.Employees");
            DropIndex("dbo.Projects", new[] { "Employees_Id" });
            DropColumn("dbo.Projects", "Employees_Id");
            DropColumn("dbo.Projects", "ManagerId");
        }
    }
}
