namespace HOCAF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InstructorProgramaDeFormacion")]
    public partial class InstructorProgramaDeFormacion
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idPersonaInstructor { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idPrograma { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idEspecialidad { get; set; }

        public bool estado { get; set; }

        public virtual Instructor Instructor { get; set; }

        public virtual ProgramaDeFormacion ProgramaDeFormacion { get; set; }
    }
}
