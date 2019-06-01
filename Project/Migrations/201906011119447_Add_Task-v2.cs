namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Taskv2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Tasks", new[] { "Employees_Id" });
            DropForeignKey("dbo.Tasks", "Employees_Id", "dbo.Employees");
            DropColumn("dbo.Tasks", "Employees_Id");
        }
        
        public override void Down()
        {
        }
    }
}
