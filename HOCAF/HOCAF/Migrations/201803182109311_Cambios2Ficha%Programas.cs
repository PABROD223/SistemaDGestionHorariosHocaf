namespace HOCAF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cambios2FichaProgramas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ficha", "ProgramaDeFormacion_idPrograma", "dbo.ProgramaDeFormacion");
            DropIndex("dbo.Ficha", new[] { "ProgramaDeFormacion_idPrograma" });
            DropColumn("dbo.Ficha", "ProgramaDeFormacion_idPrograma");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ficha", "ProgramaDeFormacion_idPrograma", c => c.Int(nullable: false));
            CreateIndex("dbo.Ficha", "ProgramaDeFormacion_idPrograma");
            AddForeignKey("dbo.Ficha", "ProgramaDeFormacion_idPrograma", "dbo.ProgramaDeFormacion", "idPrograma");
        }
    }
}
