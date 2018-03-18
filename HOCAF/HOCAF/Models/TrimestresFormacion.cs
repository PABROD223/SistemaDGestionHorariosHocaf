namespace HOCAF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrimestresFormacion")]
    public partial class TrimestresFormacion
    {
        [Key]
        [Required(ErrorMessage = "Ingrese los datos requeridos para el campo {0}")]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idTrimestre { get; set; }

        [Key]
        [Required(ErrorMessage = "Ingrese los datos requeridos para el campo {0}")]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idjornadaJTF { get; set; }

        [Key]
        [Required(ErrorMessage = "Ingrese los datos requeridos para el campo {0}")]
        [Column(Order = 2)]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idTipoFormacionJTF { get; set; }

        public bool estado { get; set; }

        public virtual JornadaTipoFormacion JornadaTipoFormacion { get; set; }

        public virtual Trimestre Trimestre { get; set; }
    }
}
