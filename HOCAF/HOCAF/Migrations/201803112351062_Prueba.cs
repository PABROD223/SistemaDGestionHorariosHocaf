namespace HOCAF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Prueba : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TipoDocumento", "nombreDocumento", c => c.String(nullable: false, maxLength: 30, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TipoDocumento", "nombreDocumento", c => c.String(nullable: false, maxLength: 20, unicode: false));
        }
    }
}
