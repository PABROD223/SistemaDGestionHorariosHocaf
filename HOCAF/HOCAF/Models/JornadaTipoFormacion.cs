namespace HOCAF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JornadaTipoFormacion")]
    public partial class JornadaTipoFormacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JornadaTipoFormacion()
        {
            TrimestresFormacion = new HashSet<TrimestresFormacion>();
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "ingrese los datos para el campo{0}")]
        [Display(Name = "Jornada")]
        public int idJornada { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "ingrese los datos para el campo{0}")]
        [Display(Name = "Tipo de Formacion")]
        public int idTipoFormacion { get; set; }

        [Display(Name = "Estado")]
        public bool estado { get; set; }

        public virtual Jornada Jornada { get; set; }

        public virtual TipoFormacion TipoFormacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrimestresFormacion> TrimestresFormacion { get; set; }
    }
}
