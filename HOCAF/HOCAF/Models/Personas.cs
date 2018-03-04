namespace HOCAF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Personas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personas()
        {
            RolDePersona = new HashSet<RolDePersona>();
        }

        [Key]
        public int idPersona { get; set; }

        [Required]
        [StringLength(50)]
        public string nombres { get; set; }

        [Required]
        [StringLength(50)]
        public string apellidos { get; set; }

        public int idDocumento { get; set; }

        [Required]
        [StringLength(50)]
        public string numeroDocumento { get; set; }

        [StringLength(7)]
        public string telefono { get; set; }

        [Required]
        [StringLength(10)]
        public string celular { get; set; }

        [Required]
        [StringLength(50)]
        public string direccion { get; set; }

        public virtual Instructor Instructor { get; set; }

        public virtual TipoDocumento TipoDocumento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RolDePersona> RolDePersona { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
