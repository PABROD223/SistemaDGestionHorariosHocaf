namespace HOCAF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Verificacion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Personas", "telefono", c => c.String(nullable: false, maxLength: 7, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Personas", "telefono", c => c.String(maxLength: 7, unicode: false));
        }
    }
}
