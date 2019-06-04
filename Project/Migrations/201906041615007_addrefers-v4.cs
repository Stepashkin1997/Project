namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrefersv4 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Projects", "ManagerId");
            AddForeignKey("dbo.Projects", "ManagerId", "dbo.Employees", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "ManagerId", "dbo.Employees");
            DropIndex("dbo.Projects", new[] { "ManagerId" });
        }
    }
}
