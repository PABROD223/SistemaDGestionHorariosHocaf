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
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idTrimestre { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idjornadaJTF { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idTipoFormacionJTF { get; set; }

        public bool estado { get; set; }

        public virtual JornadaTipoFormacion JornadaTipoFormacion { get; set; }

        public virtual Trimestre Trimestre { get; set; }
    }
}
