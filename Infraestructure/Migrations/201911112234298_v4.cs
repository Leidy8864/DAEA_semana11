namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "StudentLastName", c => c.String(nullable: false));
            DropColumn("dbo.Students", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "LastName", c => c.String(nullable: false));
            DropColumn("dbo.Students", "StudentLastName");
        }
    }
}
