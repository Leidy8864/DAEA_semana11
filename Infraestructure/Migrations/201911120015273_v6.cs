namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Students", new[] { "StundentID" });
            DropColumn("dbo.Students", "StundentID");
            AddColumn("dbo.Students", "StudentID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Students", "StudentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "StundentID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Students");
            DropColumn("dbo.Students", "StudentID");
            AddPrimaryKey("dbo.Students", "StundentID");
        }
    }
}
