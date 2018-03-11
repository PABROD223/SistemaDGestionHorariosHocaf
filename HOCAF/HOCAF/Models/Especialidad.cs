namespace HOCAF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Especialidad")]
    public partial class Especialidad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Especialidad()
        {
            ProgramaDeFormacion = new HashSet<ProgramaDeFormacion>();
        }

        [Key]
        public int idEspecialidad { get; set; }

        [Display(Name = "Nombre de especialidad")]
        [Required(ErrorMessage = "Ingrese los datos para el campo {0}")]
        [StringLength(50)]
        public string nombre { get; set; }

        [Display(Name = "Estado de la especialidad")]
        public bool estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProgramaDeFormacion> ProgramaDeFormacion { get; set; }
    }
}
