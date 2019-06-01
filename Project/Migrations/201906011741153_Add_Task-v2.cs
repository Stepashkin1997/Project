namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Taskv2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "Project", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "Project");
        }
    }
}
