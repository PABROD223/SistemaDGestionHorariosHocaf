namespace HOCAF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioFichasProgramasFormacion : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Ficha", "idProgramaFormacion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ficha", "idProgramaFormacion", c => c.Int(nullable: false));
        }
    }
}
