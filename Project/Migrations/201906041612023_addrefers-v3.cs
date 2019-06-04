namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrefersv3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "Employees_Id", "dbo.Employees");
            DropIndex("dbo.Projects", new[] { "Employees_Id" });
            DropColumn("dbo.Projects", "Employees_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "Employees_Id", c => c.Int());
            CreateIndex("dbo.Projects", "Employees_Id");
            AddForeignKey("dbo.Projects", "Employees_Id", "dbo.Employees", "Id");
        }
    }
}
