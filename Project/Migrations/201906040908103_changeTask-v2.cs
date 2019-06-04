namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeTaskv2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "Customer", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "Executor", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "Info_Executor", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "Info_Executor", c => c.String());
            AlterColumn("dbo.Projects", "Executor", c => c.String());
            AlterColumn("dbo.Projects", "Customer", c => c.String());
            AlterColumn("dbo.Projects", "Name", c => c.String());
        }
    }
}
