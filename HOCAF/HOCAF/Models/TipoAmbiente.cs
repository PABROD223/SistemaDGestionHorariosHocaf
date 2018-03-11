namespace HOCAF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TipoAmbiente")]
    public partial class TipoAmbiente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoAmbiente()
        {
            Ambiente = new HashSet<Ambiente>();
        }

        [Key]
        public int idTipoAmbiente { get; set; }

        [Display(Name = "Nombre del ambiente")]
        [Required(ErrorMessage = "ingrese los datos para el campo{0}")]
        [StringLength(50)]
        public string nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ambiente> Ambiente { get; set; }
    }
}
