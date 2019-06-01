namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Middle_name = c.String(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Customer = c.String(),
                        Executor = c.String(),
                        Manager = c.Int(nullable: false),
                        Date_start = c.DateTime(nullable: false),
                        Date_end = c.DateTime(nullable: false),
                        Info_Executor = c.String(),
                        Priority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects_Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Employee = c.Int(nullable: false),
                        Project = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Projects_Employees");
            DropTable("dbo.Projects");
            DropTable("dbo.Employees");
        }
    }
}
