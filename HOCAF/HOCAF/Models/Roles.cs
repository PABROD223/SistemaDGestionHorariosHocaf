namespace HOCAF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Roles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Roles()
        {
            RolDePersona = new HashSet<RolDePersona>();
        }

        [Key]
        public int idRol { get; set; }

        [Required(ErrorMessage = "Ingrese los datos requeridos para el campo {0}")]
        [StringLength(50)]
        public string nombreRol { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RolDePersona> RolDePersona { get; set; }
    }
}
