namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_table : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Projects_Employees", newName: "EmpinPrjs");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.EmpinPrjs", newName: "Projects_Employees");
        }
    }
}
