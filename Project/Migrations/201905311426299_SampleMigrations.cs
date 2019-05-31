namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigrations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "Manager", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "Manager", c => c.String());
        }
    }
}
