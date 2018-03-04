namespace HOCAF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ficha")]
    public partial class Ficha
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ficha()
        {
            Horario = new HashSet<Horario>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idFicha { get; set; }

        public int idJornada { get; set; }

        public int idEstadoFicha { get; set; }

        [Column(TypeName = "date")]
        public DateTime fechaInicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime fechaFin { get; set; }

        public int idProgramaFormacion { get; set; }

        public int idEspecialidadPF { get; set; }

        public virtual EstadoFicha EstadoFicha { get; set; }

        public virtual Jornada Jornada { get; set; }

        public virtual Jornada Jornada1 { get; set; }

        public virtual ProgramaDeFormacion ProgramaDeFormacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Horario> Horario { get; set; }
    }
}
