namespace HOCAF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Horario")]
    public partial class Horario
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idFicha { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idVersion { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idDia { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idTrimestreActual { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idTrimestre { get; set; }

        [Key]
        [Column(Order = 5)]
        public TimeSpan horaInicio { get; set; }

        public TimeSpan horaFin { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idAmbiente { get; set; }

        public int idEstado { get; set; }

        public virtual Ambiente Ambiente { get; set; }

        public virtual Dia Dia { get; set; }

        public virtual EstadoHorario EstadoHorario { get; set; }

        public virtual Ficha Ficha { get; set; }

        public virtual Trimestre Trimestre { get; set; }

        public virtual TrimestreActual TrimestreActual { get; set; }

        public virtual Versiones Versiones { get; set; }
    }
}
