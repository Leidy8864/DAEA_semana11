namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Codigo", c => c.String(nullable: false));
            AddColumn("dbo.Students", "StudentLastName", c => c.String(nullable: false));
            AddColumn("dbo.Students", "FechaCreacion", c => c.DateTime());
            AddColumn("dbo.Students", "FechaModificacion", c => c.DateTime());
            AddColumn("dbo.Students", "Activo", c => c.Boolean());
        }

        public override void Down()
        {
            DropColumn("dbo.Students", "Activo");
            DropColumn("dbo.Students", "FechaModificacion");
            DropColumn("dbo.Students", "FechaCreacion");
            DropColumn("dbo.Students", "StudentLastName");
            DropColumn("dbo.Students", "Codigo");
        }
    }
}
