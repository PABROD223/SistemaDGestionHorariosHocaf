namespace HOCAF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sede")]
    public partial class Sede
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sede()
        {
            Ambiente = new HashSet<Ambiente>();
        }

        [Key]
        public int idSede { get; set; }

        [Display(Name = "Nombre de la sede")]
        [Required(ErrorMessage = "ingrese los datos para el campo{0}")]        
        [StringLength(50)]
        public string nombre { get; set; }

        [Display(Name = "Número de teléfono")]
        [Required(ErrorMessage = "ingrese los datos para el campo{0}")]        
        [StringLength(7)]
        public string telefono { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "ingrese los datos para el campo{0}")]       
        [StringLength(30)]
        public string direccion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ambiente> Ambiente { get; set; }
    }
}
