namespace HOCAF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ambiente")]
    public partial class Ambiente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ambiente()
        {
            Horario = new HashSet<Horario>();
        }

        [Key]
        public int idAmbiente { get; set; }

        public int idSede { get; set; }

        [Display(Name = "Nombre del ambiente")]
        [Required(ErrorMessage = "ingrese los datos para el campo{0}")]
        [StringLength(50)]
        public string nombre { get; set; }

        [Display(Name = "Tipo ambiente")]
        public int idTipoAmbiente { get; set; }

        [Display(Name = "Estado del ambiente")]
        public bool estado { get; set; }

        public virtual Sede Sede { get; set; }

        [Display(Name = "Tipo ambiente")]
        public virtual TipoAmbiente TipoAmbiente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Horario> Horario { get; set; }
    }
}
