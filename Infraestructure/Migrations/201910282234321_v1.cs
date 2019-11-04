namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                {
                    StundentID = c.Int(nullable: false, identity: true),
                    StudentName = c.String(nullable: false),
                    StudentAddress = c.String(nullable: false),
                })
                .PrimaryKey(t => t.StundentID);

        }

        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
