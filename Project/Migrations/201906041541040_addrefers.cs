namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrefers : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.EmpinPrjs", "EmployeeId");
            CreateIndex("dbo.EmpinPrjs", "ProjectId");
            AddForeignKey("dbo.EmpinPrjs", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EmpinPrjs", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmpinPrjs", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.EmpinPrjs", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmpinPrjs", new[] { "ProjectId" });
            DropIndex("dbo.EmpinPrjs", new[] { "EmployeeId" });
        }
    }
}
