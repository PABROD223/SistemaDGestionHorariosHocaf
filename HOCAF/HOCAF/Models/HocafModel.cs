namespace HOCAF.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HocafModel : DbContext
    {
        public HocafModel()
            : base("name=HocafDB")
        {
        }

        public virtual DbSet<Ambiente> Ambiente { get; set; }
        public virtual DbSet<Dia> Dia { get; set; }
        public virtual DbSet<Especialidad> Especialidad { get; set; }
        public virtual DbSet<EstadoFicha> EstadoFicha { get; set; }
        public virtual DbSet<EstadoHorario> EstadoHorario { get; set; }
        public virtual DbSet<Ficha> Ficha { get; set; }
        public virtual DbSet<Horario> Horario { get; set; }
        public virtual DbSet<Instructor> Instructor { get; set; }
        public virtual DbSet<InstructorProgramaDeFormacion> InstructorProgramaDeFormacion { get; set; }
        public virtual DbSet<Jornada> Jornada { get; set; }
        public virtual DbSet<JornadaTipoFormacion> JornadaTipoFormacion { get; set; }
        public virtual DbSet<Personas> Personas { get; set; }
        public virtual DbSet<ProgramaDeFormacion> ProgramaDeFormacion { get; set; }
        public virtual DbSet<RolDePersona> RolDePersona { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Sede> Sede { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TipoAmbiente> TipoAmbiente { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }
        public virtual DbSet<TipoFormacion> TipoFormacion { get; set; }
        public virtual DbSet<Trimestre> Trimestre { get; set; }
        public virtual DbSet<TrimestreActual> TrimestreActual { get; set; }
        public virtual DbSet<TrimestresFormacion> TrimestresFormacion { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Versiones> Versiones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ambiente>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Ambiente>()
                .HasMany(e => e.Horario)
                .WithRequired(e => e.Ambiente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dia>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Dia>()
                .HasMany(e => e.Horario)
                .WithRequired(e => e.Dia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Especialidad>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Especialidad>()
                .HasMany(e => e.ProgramaDeFormacion)
                .WithRequired(e => e.Especialidad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstadoFicha>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<EstadoFicha>()
                .HasMany(e => e.Ficha)
                .WithRequired(e => e.EstadoFicha)
                .HasForeignKey(e => e.idEstadoFicha)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstadoHorario>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<EstadoHorario>()
                .HasMany(e => e.Horario)
                .WithRequired(e => e.EstadoHorario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ficha>()
                .HasMany(e => e.Horario)
                .WithRequired(e => e.Ficha)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Instructor>()
                .Property(e => e.cargo)
                .IsUnicode(false);

            modelBuilder.Entity<Instructor>()
                .HasMany(e => e.InstructorProgramaDeFormacion)
                .WithRequired(e => e.Instructor)
                .HasForeignKey(e => e.idPersonaInstructor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Jornada>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Jornada>()
                .HasMany(e => e.Ficha)
                .WithRequired(e => e.Jornada)
                .HasForeignKey(e => e.idJornada)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Jornada>()
                .HasMany(e => e.Ficha1)
                .WithRequired(e => e.Jornada1)
                .HasForeignKey(e => e.idJornada)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Jornada>()
                .HasMany(e => e.JornadaTipoFormacion)
                .WithRequired(e => e.Jornada)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<JornadaTipoFormacion>()
                .HasMany(e => e.TrimestresFormacion)
                .WithRequired(e => e.JornadaTipoFormacion)
                .HasForeignKey(e => new { e.idjornadaJTF, e.idTipoFormacionJTF })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Personas>()
                .Property(e => e.nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Personas>()
                .Property(e => e.apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Personas>()
                .Property(e => e.numeroDocumento)
                .IsUnicode(false);

            modelBuilder.Entity<Personas>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Personas>()
                .Property(e => e.celular)
                .IsUnicode(false);

            modelBuilder.Entity<Personas>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Personas>()
                .HasOptional(e => e.Instructor)
                .WithRequired(e => e.Personas);

            modelBuilder.Entity<Personas>()
                .HasMany(e => e.RolDePersona)
                .WithRequired(e => e.Personas)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Personas>()
                .HasOptional(e => e.Usuario)
                .WithRequired(e => e.Personas);

            modelBuilder.Entity<ProgramaDeFormacion>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<ProgramaDeFormacion>()
                .Property(e => e.siglas)
                .IsUnicode(false);

            modelBuilder.Entity<ProgramaDeFormacion>()
                .HasMany(e => e.Ficha)
                .WithRequired(e => e.ProgramaDeFormacion)
        
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProgramaDeFormacion>()
                .HasMany(e => e.InstructorProgramaDeFormacion)
                .WithRequired(e => e.ProgramaDeFormacion)
           
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Roles>()
                .Property(e => e.nombreRol)
                .IsUnicode(false);

            modelBuilder.Entity<Roles>()
                .HasMany(e => e.RolDePersona)
                .WithRequired(e => e.Roles)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sede>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Sede>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Sede>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Sede>()
                .HasMany(e => e.Ambiente)
                .WithRequired(e => e.Sede)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoAmbiente>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TipoAmbiente>()
                .HasMany(e => e.Ambiente)
                .WithRequired(e => e.TipoAmbiente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoDocumento>()
                .Property(e => e.nombreDocumento)
                .IsUnicode(false);

            modelBuilder.Entity<TipoDocumento>()
                .HasMany(e => e.Personas)
                .WithRequired(e => e.TipoDocumento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoFormacion>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TipoFormacion>()
                .HasMany(e => e.JornadaTipoFormacion)
                .WithRequired(e => e.TipoFormacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoFormacion>()
                .HasMany(e => e.ProgramaDeFormacion)
                .WithRequired(e => e.TipoFormacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trimestre>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Trimestre>()
                .HasMany(e => e.Horario)
                .WithRequired(e => e.Trimestre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trimestre>()
                .HasMany(e => e.TrimestresFormacion)
                .WithRequired(e => e.Trimestre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TrimestreActual>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TrimestreActual>()
                .HasMany(e => e.Horario)
                .WithRequired(e => e.TrimestreActual)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.correo)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.contraseña)
                .IsUnicode(false);

            modelBuilder.Entity<Versiones>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Versiones>()
                .HasMany(e => e.Horario)
                .WithRequired(e => e.Versiones)
                .WillCascadeOnDelete(false);
        }
    }
}
