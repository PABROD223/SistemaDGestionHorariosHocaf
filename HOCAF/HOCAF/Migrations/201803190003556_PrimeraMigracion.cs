namespace HOCAF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeraMigracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ambiente",
                c => new
                    {
                        idAmbiente = c.Int(nullable: false, identity: true),
                        idSede = c.Int(nullable: false),
                        nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        idTipoAmbiente = c.Int(nullable: false),
                        estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idAmbiente)
                .ForeignKey("dbo.Sede", t => t.idSede)
                .ForeignKey("dbo.TipoAmbiente", t => t.idTipoAmbiente)
                .Index(t => t.idSede)
                .Index(t => t.idTipoAmbiente);
            
            CreateTable(
                "dbo.Horario",
                c => new
                    {
                        idFicha = c.Int(nullable: false),
                        idVersion = c.Int(nullable: false),
                        idDia = c.Int(nullable: false),
                        idTrimestreActual = c.Int(nullable: false),
                        idTrimestre = c.Int(nullable: false),
                        horaInicio = c.Time(nullable: false, precision: 7),
                        idAmbiente = c.Int(nullable: false),
                        horaFin = c.Time(nullable: false, precision: 7),
                        idEstado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.idFicha, t.idVersion, t.idDia, t.idTrimestreActual, t.idTrimestre, t.horaInicio, t.idAmbiente })
                .ForeignKey("dbo.Dia", t => t.idDia)
                .ForeignKey("dbo.EstadoHorario", t => t.idEstado)
                .ForeignKey("dbo.Ficha", t => t.idFicha)
                .ForeignKey("dbo.Trimestre", t => t.idTrimestre)
                .ForeignKey("dbo.TrimestreActual", t => t.idTrimestreActual)
                .ForeignKey("dbo.Versiones", t => t.idVersion)
                .ForeignKey("dbo.Ambiente", t => t.idAmbiente)
                .Index(t => t.idFicha)
                .Index(t => t.idVersion)
                .Index(t => t.idDia)
                .Index(t => t.idTrimestreActual)
                .Index(t => t.idTrimestre)
                .Index(t => t.idAmbiente)
                .Index(t => t.idEstado);
            
            CreateTable(
                "dbo.Dia",
                c => new
                    {
                        idDia = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.idDia);
            
            CreateTable(
                "dbo.EstadoHorario",
                c => new
                    {
                        idEstado = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.idEstado);
            
            CreateTable(
                "dbo.Ficha",
                c => new
                    {
                        idFicha = c.Int(nullable: false),
                        idJornada = c.Int(nullable: false),
                        idEstadoFicha = c.Int(nullable: false),
                        fechaInicio = c.DateTime(nullable: false, storeType: "date"),
                        fechaFin = c.DateTime(nullable: false, storeType: "date"),
                        idPrograma = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idFicha)
                .ForeignKey("dbo.EstadoFicha", t => t.idEstadoFicha)
                .ForeignKey("dbo.Jornada", t => t.idJornada)
                .ForeignKey("dbo.ProgramaDeFormacion", t => t.idPrograma, cascadeDelete: true)
                .Index(t => t.idJornada)
                .Index(t => t.idEstadoFicha)
                .Index(t => t.idPrograma);
            
            CreateTable(
                "dbo.EstadoFicha",
                c => new
                    {
                        idEstado = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.idEstado);
            
            CreateTable(
                "dbo.Jornada",
                c => new
                    {
                        idJornada = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idJornada);
            
            CreateTable(
                "dbo.JornadaTipoFormacion",
                c => new
                    {
                        idJornada = c.Int(nullable: false),
                        idTipoFormacion = c.Int(nullable: false),
                        estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.idJornada, t.idTipoFormacion })
                .ForeignKey("dbo.TipoFormacion", t => t.idTipoFormacion)
                .ForeignKey("dbo.Jornada", t => t.idJornada)
                .Index(t => t.idJornada)
                .Index(t => t.idTipoFormacion);
            
            CreateTable(
                "dbo.TipoFormacion",
                c => new
                    {
                        idTipoFormacion = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idTipoFormacion);
            
            CreateTable(
                "dbo.ProgramaDeFormacion",
                c => new
                    {
                        idPrograma = c.Int(nullable: false),
                        nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        siglas = c.String(nullable: false, maxLength: 50, unicode: false),
                        idEspecialidad = c.Int(nullable: false),
                        idTipoFormacion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idPrograma)
                .ForeignKey("dbo.Especialidad", t => t.idEspecialidad)
                .ForeignKey("dbo.TipoFormacion", t => t.idTipoFormacion)
                .Index(t => t.idEspecialidad)
                .Index(t => t.idTipoFormacion);
            
            CreateTable(
                "dbo.Especialidad",
                c => new
                    {
                        idEspecialidad = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idEspecialidad);
            
            CreateTable(
                "dbo.InstructorProgramaDeFormacion",
                c => new
                    {
                        idPersonaInstructor = c.Int(nullable: false),
                        idPrograma = c.Int(nullable: false),
                        estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.idPersonaInstructor, t.idPrograma })
                .ForeignKey("dbo.Instructor", t => t.idPersonaInstructor)
                .ForeignKey("dbo.ProgramaDeFormacion", t => t.idPrograma)
                .Index(t => t.idPersonaInstructor)
                .Index(t => t.idPrograma);
            
            CreateTable(
                "dbo.Instructor",
                c => new
                    {
                        idPersona = c.Int(nullable: false),
                        cargo = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.idPersona)
                .ForeignKey("dbo.Personas", t => t.idPersona)
                .Index(t => t.idPersona);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        idPersona = c.Int(nullable: false, identity: true),
                        nombres = c.String(nullable: false, maxLength: 50, unicode: false),
                        apellidos = c.String(nullable: false, maxLength: 50, unicode: false),
                        idDocumento = c.Int(nullable: false),
                        numeroDocumento = c.String(nullable: false, maxLength: 50, unicode: false),
                        telefono = c.String(nullable: false, maxLength: 7, unicode: false),
                        celular = c.String(nullable: false, maxLength: 10, unicode: false),
                        direccion = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.idPersona)
                .ForeignKey("dbo.TipoDocumento", t => t.idDocumento)
                .Index(t => t.idDocumento);
            
            CreateTable(
                "dbo.RolDePersona",
                c => new
                    {
                        idPersona = c.Int(nullable: false),
                        idRol = c.Int(nullable: false),
                        estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.idPersona, t.idRol })
                .ForeignKey("dbo.Roles", t => t.idRol)
                .ForeignKey("dbo.Personas", t => t.idPersona)
                .Index(t => t.idPersona)
                .Index(t => t.idRol);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        idRol = c.Int(nullable: false, identity: true),
                        nombreRol = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.idRol);
            
            CreateTable(
                "dbo.TipoDocumento",
                c => new
                    {
                        idDocumento = c.Int(nullable: false, identity: true),
                        nombreDocumento = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.idDocumento);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        idPersona = c.Int(nullable: false),
                        correo = c.String(nullable: false, maxLength: 50, unicode: false),
                        contraseña = c.String(nullable: false, maxLength: 500, unicode: false),
                        fechaIngreso = c.DateTime(nullable: false, storeType: "date"),
                        estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idPersona)
                .ForeignKey("dbo.Personas", t => t.idPersona)
                .Index(t => t.idPersona);
            
            CreateTable(
                "dbo.TrimestresFormacion",
                c => new
                    {
                        idTrimestre = c.Int(nullable: false),
                        idjornadaJTF = c.Int(nullable: false),
                        idTipoFormacionJTF = c.Int(nullable: false),
                        estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.idTrimestre, t.idjornadaJTF, t.idTipoFormacionJTF })
                .ForeignKey("dbo.Trimestre", t => t.idTrimestre)
                .ForeignKey("dbo.JornadaTipoFormacion", t => new { t.idjornadaJTF, t.idTipoFormacionJTF })
                .Index(t => t.idTrimestre)
                .Index(t => new { t.idjornadaJTF, t.idTipoFormacionJTF });
            
            CreateTable(
                "dbo.Trimestre",
                c => new
                    {
                        idTrimestre = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.idTrimestre);
            
            CreateTable(
                "dbo.TrimestreActual",
                c => new
                    {
                        idTrimestreActual = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idTrimestreActual);
            
            CreateTable(
                "dbo.Versiones",
                c => new
                    {
                        idVersion = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        estado = c.Boolean(nullable: false),
                        fechaInicio = c.DateTime(nullable: false, storeType: "date"),
                        fechaFin = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.idVersion);
            
            CreateTable(
                "dbo.Sede",
                c => new
                    {
                        idSede = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        telefono = c.String(nullable: false, maxLength: 7, unicode: false),
                        direccion = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.idSede);
            
            CreateTable(
                "dbo.TipoAmbiente",
                c => new
                    {
                        idTipoAmbiente = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.idTipoAmbiente);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ambiente", "idTipoAmbiente", "dbo.TipoAmbiente");
            DropForeignKey("dbo.Ambiente", "idSede", "dbo.Sede");
            DropForeignKey("dbo.Horario", "idAmbiente", "dbo.Ambiente");
            DropForeignKey("dbo.Horario", "idVersion", "dbo.Versiones");
            DropForeignKey("dbo.Horario", "idTrimestreActual", "dbo.TrimestreActual");
            DropForeignKey("dbo.JornadaTipoFormacion", "idJornada", "dbo.Jornada");
            DropForeignKey("dbo.TrimestresFormacion", new[] { "idjornadaJTF", "idTipoFormacionJTF" }, "dbo.JornadaTipoFormacion");
            DropForeignKey("dbo.TrimestresFormacion", "idTrimestre", "dbo.Trimestre");
            DropForeignKey("dbo.Horario", "idTrimestre", "dbo.Trimestre");
            DropForeignKey("dbo.ProgramaDeFormacion", "idTipoFormacion", "dbo.TipoFormacion");
            DropForeignKey("dbo.InstructorProgramaDeFormacion", "idPrograma", "dbo.ProgramaDeFormacion");
            DropForeignKey("dbo.Usuario", "idPersona", "dbo.Personas");
            DropForeignKey("dbo.Personas", "idDocumento", "dbo.TipoDocumento");
            DropForeignKey("dbo.RolDePersona", "idPersona", "dbo.Personas");
            DropForeignKey("dbo.RolDePersona", "idRol", "dbo.Roles");
            DropForeignKey("dbo.Instructor", "idPersona", "dbo.Personas");
            DropForeignKey("dbo.InstructorProgramaDeFormacion", "idPersonaInstructor", "dbo.Instructor");
            DropForeignKey("dbo.Ficha", "idPrograma", "dbo.ProgramaDeFormacion");
            DropForeignKey("dbo.ProgramaDeFormacion", "idEspecialidad", "dbo.Especialidad");
            DropForeignKey("dbo.JornadaTipoFormacion", "idTipoFormacion", "dbo.TipoFormacion");
            DropForeignKey("dbo.Ficha", "idJornada", "dbo.Jornada");
            DropForeignKey("dbo.Horario", "idFicha", "dbo.Ficha");
            DropForeignKey("dbo.Ficha", "idEstadoFicha", "dbo.EstadoFicha");
            DropForeignKey("dbo.Horario", "idEstado", "dbo.EstadoHorario");
            DropForeignKey("dbo.Horario", "idDia", "dbo.Dia");
            DropIndex("dbo.TrimestresFormacion", new[] { "idjornadaJTF", "idTipoFormacionJTF" });
            DropIndex("dbo.TrimestresFormacion", new[] { "idTrimestre" });
            DropIndex("dbo.Usuario", new[] { "idPersona" });
            DropIndex("dbo.RolDePersona", new[] { "idRol" });
            DropIndex("dbo.RolDePersona", new[] { "idPersona" });
            DropIndex("dbo.Personas", new[] { "idDocumento" });
            DropIndex("dbo.Instructor", new[] { "idPersona" });
            DropIndex("dbo.InstructorProgramaDeFormacion", new[] { "idPrograma" });
            DropIndex("dbo.InstructorProgramaDeFormacion", new[] { "idPersonaInstructor" });
            DropIndex("dbo.ProgramaDeFormacion", new[] { "idTipoFormacion" });
            DropIndex("dbo.ProgramaDeFormacion", new[] { "idEspecialidad" });
            DropIndex("dbo.JornadaTipoFormacion", new[] { "idTipoFormacion" });
            DropIndex("dbo.JornadaTipoFormacion", new[] { "idJornada" });
            DropIndex("dbo.Ficha", new[] { "idPrograma" });
            DropIndex("dbo.Ficha", new[] { "idEstadoFicha" });
            DropIndex("dbo.Ficha", new[] { "idJornada" });
            DropIndex("dbo.Horario", new[] { "idEstado" });
            DropIndex("dbo.Horario", new[] { "idAmbiente" });
            DropIndex("dbo.Horario", new[] { "idTrimestre" });
            DropIndex("dbo.Horario", new[] { "idTrimestreActual" });
            DropIndex("dbo.Horario", new[] { "idDia" });
            DropIndex("dbo.Horario", new[] { "idVersion" });
            DropIndex("dbo.Horario", new[] { "idFicha" });
            DropIndex("dbo.Ambiente", new[] { "idTipoAmbiente" });
            DropIndex("dbo.Ambiente", new[] { "idSede" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.TipoAmbiente");
            DropTable("dbo.Sede");
            DropTable("dbo.Versiones");
            DropTable("dbo.TrimestreActual");
            DropTable("dbo.Trimestre");
            DropTable("dbo.TrimestresFormacion");
            DropTable("dbo.Usuario");
            DropTable("dbo.TipoDocumento");
            DropTable("dbo.Roles");
            DropTable("dbo.RolDePersona");
            DropTable("dbo.Personas");
            DropTable("dbo.Instructor");
            DropTable("dbo.InstructorProgramaDeFormacion");
            DropTable("dbo.Especialidad");
            DropTable("dbo.ProgramaDeFormacion");
            DropTable("dbo.TipoFormacion");
            DropTable("dbo.JornadaTipoFormacion");
            DropTable("dbo.Jornada");
            DropTable("dbo.EstadoFicha");
            DropTable("dbo.Ficha");
            DropTable("dbo.EstadoHorario");
            DropTable("dbo.Dia");
            DropTable("dbo.Horario");
            DropTable("dbo.Ambiente");
        }
    }
}
