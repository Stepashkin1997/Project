namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeTabels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Middle_name", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "email", c => c.String());
            AlterColumn("dbo.Employees", "Middle_name", c => c.String());
            AlterColumn("dbo.Employees", "Surname", c => c.String());
            AlterColumn("dbo.Employees", "Name", c => c.String());
        }
    }
}
