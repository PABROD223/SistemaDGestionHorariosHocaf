namespace HOCAF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CabioRelacionProgramaFormacion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ficha", new[] { "idProgramaFormacion", "idEspecialidadPF" }, "dbo.ProgramaDeFormacion");
            DropForeignKey("dbo.InstructorProgramaDeFormacion", new[] { "idPrograma", "idEspecialidad" }, "dbo.ProgramaDeFormacion");
            DropIndex("dbo.Ficha", new[] { "idProgramaFormacion", "idEspecialidadPF" });
            DropIndex("dbo.InstructorProgramaDeFormacion", new[] { "idPrograma", "idEspecialidad" });
            DropPrimaryKey("dbo.ProgramaDeFormacion");
            DropPrimaryKey("dbo.InstructorProgramaDeFormacion");
            AddColumn("dbo.Ficha", "ProgramaDeFormacion_idPrograma", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ProgramaDeFormacion", "idPrograma");
            AddPrimaryKey("dbo.InstructorProgramaDeFormacion", new[] { "idPersonaInstructor", "idPrograma" });
            CreateIndex("dbo.Ficha", "ProgramaDeFormacion_idPrograma");
            CreateIndex("dbo.InstructorProgramaDeFormacion", "idPrograma");
            AddForeignKey("dbo.Ficha", "ProgramaDeFormacion_idPrograma", "dbo.ProgramaDeFormacion", "idPrograma");
            AddForeignKey("dbo.InstructorProgramaDeFormacion", "idPrograma", "dbo.ProgramaDeFormacion", "idPrograma");
            DropColumn("dbo.Ficha", "idEspecialidadPF");
            DropColumn("dbo.InstructorProgramaDeFormacion", "idEspecialidad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InstructorProgramaDeFormacion", "idEspecialidad", c => c.Int(nullable: false));
            AddColumn("dbo.Ficha", "idEspecialidadPF", c => c.Int(nullable: false));
            DropForeignKey("dbo.InstructorProgramaDeFormacion", "idPrograma", "dbo.ProgramaDeFormacion");
            DropForeignKey("dbo.Ficha", "ProgramaDeFormacion_idPrograma", "dbo.ProgramaDeFormacion");
            DropIndex("dbo.InstructorProgramaDeFormacion", new[] { "idPrograma" });
            DropIndex("dbo.Ficha", new[] { "ProgramaDeFormacion_idPrograma" });
            DropPrimaryKey("dbo.InstructorProgramaDeFormacion");
            DropPrimaryKey("dbo.ProgramaDeFormacion");
            DropColumn("dbo.Ficha", "ProgramaDeFormacion_idPrograma");
            AddPrimaryKey("dbo.InstructorProgramaDeFormacion", new[] { "idPersonaInstructor", "idPrograma", "idEspecialidad" });
            AddPrimaryKey("dbo.ProgramaDeFormacion", new[] { "idPrograma", "idEspecialidad" });
            CreateIndex("dbo.InstructorProgramaDeFormacion", new[] { "idPrograma", "idEspecialidad" });
            CreateIndex("dbo.Ficha", new[] { "idProgramaFormacion", "idEspecialidadPF" });
            AddForeignKey("dbo.InstructorProgramaDeFormacion", new[] { "idPrograma", "idEspecialidad" }, "dbo.ProgramaDeFormacion", new[] { "idPrograma", "idEspecialidad" });
            AddForeignKey("dbo.Ficha", new[] { "idProgramaFormacion", "idEspecialidadPF" }, "dbo.ProgramaDeFormacion", new[] { "idPrograma", "idEspecialidad" });
        }
    }
}
