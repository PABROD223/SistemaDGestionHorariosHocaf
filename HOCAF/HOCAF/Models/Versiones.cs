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

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        public bool estado { get; set; }

        [Column(TypeName = "date")]
        public DateTime fechaInicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime fechaFin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Horario> Horario { get; set; }
    }
}
