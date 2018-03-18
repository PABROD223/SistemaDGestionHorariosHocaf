namespace HOCAF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idPersona { get; set; }

        [Required(ErrorMessage = "Ingrese los datos requeridos para el campo {0}")]
        [StringLength(50)]
        public string correo { get; set; }

        [Required(ErrorMessage = "Ingrese los datos requeridos para el campo {0}")]
        [StringLength(500)]
        public string contraseña { get; set; }

        [Column(TypeName = "date")]
        public DateTime fechaIngreso { get; set; }

        public bool estado { get; set; }

        public virtual Personas Personas { get; set; }
    }
}
