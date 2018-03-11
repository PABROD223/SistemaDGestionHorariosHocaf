namespace HOCAF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProgramaDeFormacion")]
    public partial class ProgramaDeFormacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProgramaDeFormacion()
        {
            Ficha = new HashSet<Ficha>();
            InstructorProgramaDeFormacion = new HashSet<InstructorProgramaDeFormacion>();
        }

        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idPrograma { get; set; }

        [Display(Name = "Nombre programa de formación")]
        [Required(ErrorMessage = " Ingrese los datos para el campo {0}")]
        [StringLength(50)]
        public string nombre { get; set; }

        [Display(Name = "Siglas del programa de formación")]
        [Required(ErrorMessage = " Ingrese los datos para el campo {0}")]
        [StringLength(50)]
        public string siglas { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idEspecialidad { get; set; }

        public int idTipoFormacion { get; set; }

        public virtual Especialidad Especialidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ficha> Ficha { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InstructorProgramaDeFormacion> InstructorProgramaDeFormacion { get; set; }

        public virtual TipoFormacion TipoFormacion { get; set; }
    }
}
