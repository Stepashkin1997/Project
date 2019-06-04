namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete_column_info : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Projects", "Info_Executor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "Info_Executor", c => c.String(nullable: false));
        }
    }
}
