namespace HOCAF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambios : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ficha", "ProgramaDeFormacion_idPrograma", "dbo.ProgramaDeFormacion");
            RenameColumn(table: "dbo.Ficha", name: "ProgramaDeFormacion_idPrograma", newName: "idPrograma");
            RenameIndex(table: "dbo.Ficha", name: "IX_ProgramaDeFormacion_idPrograma", newName: "IX_idPrograma");
            AddForeignKey("dbo.Ficha", "idPrograma", "dbo.ProgramaDeFormacion", "idPrograma", cascadeDelete: true);
            DropColumn("dbo.Ficha", "idProgramaFormacion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ficha", "idProgramaFormacion", c => c.Int(nullable: false));
            DropForeignKey("dbo.Ficha", "idPrograma", "dbo.ProgramaDeFormacion");
            RenameIndex(table: "dbo.Ficha", name: "IX_idPrograma", newName: "IX_ProgramaDeFormacion_idPrograma");
            RenameColumn(table: "dbo.Ficha", name: "idPrograma", newName: "ProgramaDeFormacion_idPrograma");
            AddForeignKey("dbo.Ficha", "ProgramaDeFormacion_idPrograma", "dbo.ProgramaDeFormacion", "idPrograma");
        }
    }
}
