namespace HOCAF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Versiones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Versiones()
        {
            Horario = new HashSet<Horario>();
        }

        [Key]
        public int idVersion { get; set; }
        [Display(Name ="Nombre version")]
        [Required(ErrorMessage ="Ingrese los datos para el campo{0}")]
        [StringLength(50)]
        public string nombre { get; set; }

        [Display(Name = "Estado de la version")]
        public bool estado { get; set; }

        [Display(Name = "Fecha inicio Version")]
        [Required(ErrorMessage = "ingrese la fecha recquerida para el campo {0}")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime fechaInicio { get; set; }

        [Display(Name = "Fecha fin Version")]
        [Required(ErrorMessage = "ingrese la fecha recquerida para el campo {0}")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime fechaFin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Horario> Horario { get; set; }
    }
}
