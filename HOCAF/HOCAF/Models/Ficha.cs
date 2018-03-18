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

        [Display(Name= "Numero de ficha")]
        [Required (ErrorMessage = "ingrese los datos para el campo {0}")]
        public int idFicha { get; set; }

        [Display(Name = "Jornada")]
        [Required(ErrorMessage = "ingrese los datos para el campo {0}")]
        public int idJornada { get; set; }

        [Display(Name = "Estado de la ficha")]
        [Required(ErrorMessage = "ingrese los datos para el campo {0}")]
        public int idEstadoFicha { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha inicio de formación")]
        [Column(TypeName = "date")]
        public DateTime fechaInicio { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Fin de formación")]
        [Column(TypeName = "date")]
        public DateTime fechaFin { get; set; }

        public virtual EstadoFicha EstadoFicha { get; set; }

        public virtual Jornada Jornada { get; set; }

        public virtual Jornada Jornada1 { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Horario> Horario { get; set; }

        public int idPrograma { get; set; }

        public virtual ProgramaDeFormacion ProgramaDeFormacion { get; set; }
    }
}
