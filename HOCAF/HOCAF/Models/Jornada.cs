namespace HOCAF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Jornada")]
    public partial class Jornada
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Jornada()
        {
            Ficha = new HashSet<Ficha>();
            Ficha1 = new HashSet<Ficha>();
            JornadaTipoFormacion = new HashSet<JornadaTipoFormacion>();
        }

        [Key]
        public int idJornada { get; set; }
        [Display(Name= "Nombre de la Jornada")]
        [Required(ErrorMessage = "Ingrese los datos requeridos para el campo {0}")]
        [StringLength(50)]
        public string nombre { get; set; }
        [Display(Name = "Estado de la jornada")]
        public bool estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ficha> Ficha { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ficha> Ficha1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JornadaTipoFormacion> JornadaTipoFormacion { get; set; }
    }
}
